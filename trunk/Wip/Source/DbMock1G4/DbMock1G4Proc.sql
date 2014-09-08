if exists (select * from sysobjects where id = object_id(N'[sproc_Account_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_GetCount]
GO

/* Procedure sproc_Account_GetCount*/
CREATE PROCEDURE sproc_Account_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Account]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Account_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_Get]
GO

/* Procedure sproc_Account_Get*/
CREATE PROCEDURE sproc_Account_Get
AS
SELECT
	--[AccountId],
	--[CusId],
	--[AccountNo],
	--[OdId],
	--[WdId],
	--[Balance]

*
FROM
	[Account]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Account_GetByAccountId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_GetByAccountId]
GO

/* Procedure sproc_Account_GetByAccountId*/
CREATE PROCEDURE sproc_Account_GetByAccountId
@AccountId int
AS
SELECT
	--[AccountId],
	--[CusId],
	--[AccountNo],
	--[OdId],
	--[WdId],
	--[Balance]

*
FROM
	[Account]
WHERE
	[AccountId] = @AccountId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Account_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_GetPaged]
GO

/* Procedure sproc_Account_GetPaged*/
CREATE PROCEDURE sproc_Account_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [AccountId]
FROM [Account]


-- query out
SELECT *
FROM [Account]
WHERE [AccountId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Account_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_Add]
GO

/* Procedure sproc_Account_Add*/
CREATE PROCEDURE sproc_Account_Add
	@AccountId int OUTPUT
	,@CusId int
	,@AccountNo varchar(50)
	,@OdId int
	,@WdId int
	,@Balance decimal(20)

AS

	INSERT INTO [Account]
	(
		[CusId],
		[AccountNo],
		[OdId],
		[WdId],
		[Balance]
	)
	VALUES
	(
		@CusId,
		@AccountNo,
		@OdId,
		@WdId,
		@Balance
	)
	SELECT
		@AccountId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Account_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_Update]
GO

/* Procedure sproc_Account_Update*/
CREATE PROCEDURE sproc_Account_Update
	@CusId int,
	@AccountNo varchar(50),
	@OdId int,
	@WdId int,
	@Balance decimal(20),
	@AccountId int

AS
UPDATE [Account]
SET
	[CusId] = @CusId,
	[AccountNo] = @AccountNo,
	[OdId] = @OdId,
	[WdId] = @WdId,
	[Balance] = @Balance
WHERE
	[AccountId] = @AccountId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Account_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Account_Delete]
GO

/* Procedure sproc_Account_Delete*/
CREATE PROCEDURE sproc_Account_Delete
	@AccountId int
AS
DELETE
FROM
	[Account]
WHERE
	[AccountId] = @AccountId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_GetCount]
GO

/* Procedure sproc_Atm_GetCount*/
CREATE PROCEDURE sproc_Atm_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Atm]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_Get]
GO

/* Procedure sproc_Atm_Get*/
CREATE PROCEDURE sproc_Atm_Get
AS
SELECT
	--[AtmId],
	--[Branch],
	--[Address]

*
FROM
	[Atm]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_GetByAtmId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_GetByAtmId]
GO

/* Procedure sproc_Atm_GetByAtmId*/
CREATE PROCEDURE sproc_Atm_GetByAtmId
@AtmId int
AS
SELECT
	--[AtmId],
	--[Branch],
	--[Address]

*
FROM
	[Atm]
WHERE
	[AtmId] = @AtmId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_GetPaged]
GO

/* Procedure sproc_Atm_GetPaged*/
CREATE PROCEDURE sproc_Atm_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [AtmId]
FROM [Atm]


-- query out
SELECT *
FROM [Atm]
WHERE [AtmId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_Add]
GO

/* Procedure sproc_Atm_Add*/
CREATE PROCEDURE sproc_Atm_Add
	@AtmId int OUTPUT
	,@Branch nvarchar(50)
	,@Address nvarchar(100)

AS

	INSERT INTO [Atm]
	(
		[Branch],
		[Address]
	)
	VALUES
	(
		@Branch,
		@Address
	)
	SELECT
		@AtmId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_Update]
GO

/* Procedure sproc_Atm_Update*/
CREATE PROCEDURE sproc_Atm_Update
	@Branch nvarchar(50),
	@Address nvarchar(100),
	@AtmId int

AS
UPDATE [Atm]
SET
	[Branch] = @Branch,
	[Address] = @Address
WHERE
	[AtmId] = @AtmId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Atm_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Atm_Delete]
GO

/* Procedure sproc_Atm_Delete*/
CREATE PROCEDURE sproc_Atm_Delete
	@AtmId int
AS
DELETE
FROM
	[Atm]
WHERE
	[AtmId] = @AtmId
GO

-- BEGIN Procedure table Card
if exists (select * from sysobjects where id = object_id(N'[sproc_Card_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_GetCount]
GO

/* Procedure sproc_Card_GetCount*/
CREATE PROCEDURE sproc_Card_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Card]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Card_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_Get]
GO

/* Procedure sproc_Card_Get*/
CREATE PROCEDURE sproc_Card_Get
AS
SELECT
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(32),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM
	[Card]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Card_GetByCardNo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_GetByCardNo]
GO

/* Procedure sproc_Card_GetByCardNo*/
CREATE PROCEDURE sproc_Card_GetByCardNo
@CardNo varchar(16)
AS
SELECT
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(32),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM
	[Card]
WHERE
	[CardNo] = @CardNo
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_GetByCardNoPIN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_GetByCardNoPIN]
GO

/* Procedure sproc_Card_GetByCardNoPIN*/
CREATE PROCEDURE sproc_Card_GetByCardNoPIN
@CardNo varchar(16),
@HashPin varchar(1000)
AS
SELECT
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(32),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM
	[Card]
WHERE
	[CardNo] =@CardNo AND CONVERT(varchar(32),HASHBYTES('MD5', Pin),2) = @HashPin
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_GetCardNo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_GetCardNo]
GO

/* Procedure sproc_Card_GetByCardNo*/
CREATE PROCEDURE sproc_Card_GetCardNo
@CardNo varchar(16)
AS
SELECT
	[CardNo]
FROM
	[Card]
WHERE
	[CardNo] =@CardNo
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_GetHashPIN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure sproc_Card_GetHashPIN
GO

/* Procedure sproc_Card_GetHashPIN*/
CREATE PROCEDURE sproc_Card_GetHashPIN
@CardNo varchar(16)
AS
SELECT
	CONVERT(varchar(32),HASHBYTES('MD5', Pin),2) as Pin
FROM
	[Card]
WHERE
	[CardNo] = @CardNo
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_GetPaged]
GO

/* Procedure sproc_Card_GetPaged*/
CREATE PROCEDURE sproc_Card_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	varchar(16)
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [CardNo]
FROM [Card]


-- query out
SELECT 
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(32),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM [Card]
WHERE [CardNo]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_Add]
GO

/* Procedure sproc_Card_Add*/
CREATE PROCEDURE sproc_Card_Add
	@CardNo varchar(16) OUTPUT
	,@Status varchar(30)
	,@AccountId int
	,@Pin varchar(6)
	,@StartDate date
	,@ExpiredDate date
	,@Attempt int

AS

	INSERT INTO [Card]
	(
		[CardNo],
		[Status],
		[AccountId],
		[Pin],
		[StartDate],
		[ExpiredDate],
		[Attempt]
	)
	VALUES
	(
		@CardNo,
		@Status,
		@AccountId,
		@Pin,
		@StartDate,
		@ExpiredDate,
		@Attempt
	)
GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Card_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_Update]
GO

/* Procedure sproc_Card_Update*/
CREATE PROCEDURE sproc_Card_Update
	@Status varchar(30),
	@AccountId int,
	@Pin varchar(6),
	@StartDate date,
	@ExpiredDate date,
	@Attempt int,
	@CardNo varchar(16)

AS
UPDATE [Card]
SET
	[Status] = @Status,
	[AccountId] = @AccountId,
	[Pin] = @Pin,
	[StartDate] = @StartDate,
	[ExpiredDate] = @ExpiredDate,
	[Attempt] = @Attempt
WHERE
	[CardNo] = @CardNo
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_UpdateStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure sproc_Card_UpdateStatus
GO

/* Procedure sproc_Card_UpdateStatus*/
CREATE PROCEDURE sproc_Card_UpdateStatus
	@Status varchar(30),
	@Attempt int,
	@CardNo varchar(16)

AS
UPDATE [Card]
SET
	[Status] = @Status,
	[Attempt] = @Attempt
WHERE
	[CardNo] = @CardNo
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Card_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Card_Delete]
GO

/* Procedure sproc_Card_Delete*/
CREATE PROCEDURE sproc_Card_Delete
	@CardNo varchar(16)
AS
DELETE
FROM
	[Card]
WHERE
	[CardNo] = @CardNo
GO
-- END Procedure table Card

if exists (select * from sysobjects where id = object_id(N'[sproc_Config_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Config_GetCount]
GO

/* Procedure sproc_Config_GetCount*/
CREATE PROCEDURE sproc_Config_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Config]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Config_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Config_Get]
GO

/* Procedure sproc_Config_Get*/
CREATE PROCEDURE sproc_Config_Get
AS
SELECT
	--[DateModified],
	--[MinWithdraw],
	--[MaxWithdraw],
	--[NumPerPage]

*
FROM
	[Config]
GO






if exists (select * from sysobjects where id = object_id(N'[sproc_Config_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Config_Add]
GO

/* Procedure sproc_Config_Add*/
CREATE PROCEDURE sproc_Config_Add
	@DateModified date,
	@MinWithdraw decimal(20),
	@MaxWithdraw decimal(20),
	@NumPerPage int
AS

	INSERT INTO [Config]
	(
		[DateModified],
		[MinWithdraw],
		[MaxWithdraw],
		[NumPerPage]
	)
	VALUES
	(
		@DateModified,
		@MinWithdraw,
		@MaxWithdraw,
		@NumPerPage
	)
GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_GetCount]
GO

/* Procedure sproc_Customer_GetCount*/
CREATE PROCEDURE sproc_Customer_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Customer]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_Get]
GO

/* Procedure sproc_Customer_Get*/
CREATE PROCEDURE sproc_Customer_Get
AS
SELECT
	--[CusId],
	--[Name],
	--[Phone],
	--[Email],
	--[Addr]

*
FROM
	[Customer]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_GetByCusId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_GetByCusId]
GO

/* Procedure sproc_Customer_GetByCusId*/
CREATE PROCEDURE sproc_Customer_GetByCusId
@CusId int
AS
SELECT
	--[CusId],
	--[Name],
	--[Phone],
	--[Email],
	--[Addr]

*
FROM
	[Customer]
WHERE
	[CusId] = @CusId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_GetPaged]
GO

/* Procedure sproc_Customer_GetPaged*/
CREATE PROCEDURE sproc_Customer_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [CusId]
FROM [Customer]


-- query out
SELECT *
FROM [Customer]
WHERE [CusId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_Add]
GO

/* Procedure sproc_Customer_Add*/
CREATE PROCEDURE sproc_Customer_Add
	@CusId int OUTPUT
	,@Name nvarchar(100)
	,@Phone varchar(50)
	,@Email varchar(100)
	,@Addr nvarchar(200)

AS

	INSERT INTO [Customer]
	(
		[Name],
		[Phone],
		[Email],
		[Addr]
	)
	VALUES
	(
		@Name,
		@Phone,
		@Email,
		@Addr
	)
	SELECT
		@CusId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_Update]
GO

/* Procedure sproc_Customer_Update*/
CREATE PROCEDURE sproc_Customer_Update
	@Name nvarchar(100),
	@Phone varchar(50),
	@Email varchar(100),
	@Addr nvarchar(200),
	@CusId int

AS
UPDATE [Customer]
SET
	[Name] = @Name,
	[Phone] = @Phone,
	[Email] = @Email,
	[Addr] = @Addr
WHERE
	[CusId] = @CusId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Customer_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Customer_Delete]
GO

/* Procedure sproc_Customer_Delete*/
CREATE PROCEDURE sproc_Customer_Delete
	@CusId int
AS
DELETE
FROM
	[Customer]
WHERE
	[CusId] = @CusId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Log_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_GetCount]
GO

/* Procedure sproc_Log_GetCount*/
CREATE PROCEDURE sproc_Log_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Log]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Log_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_Get]
GO

/* Procedure sproc_Log_Get*/
CREATE PROCEDURE sproc_Log_Get
AS
SELECT
	--[LogId],
	--[LogTypeId],
	--[AtmId],
	--[CardNo],
	--[LogDate],
	--[Amount],
	--[Details]

*
FROM
	[Log]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Log_GetByLogId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_GetByLogId]
GO

/* Procedure sproc_Log_GetByLogId*/
CREATE PROCEDURE sproc_Log_GetByLogId
@LogId int
AS
SELECT
	--[LogId],
	--[LogTypeId],
	--[AtmId],
	--[CardNo],
	--[LogDate],
	--[Amount],
	--[Details]

*
FROM
	[Log]
WHERE
	[LogId] = @LogId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Log_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_GetPaged]
GO

/* Procedure sproc_Log_GetPaged*/
CREATE PROCEDURE sproc_Log_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [LogId]
FROM [Log]


-- query out
SELECT *
FROM [Log]
WHERE [LogId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Log_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_Add]
GO

/* Procedure sproc_Log_Add*/
CREATE PROCEDURE sproc_Log_Add
	@LogId int OUTPUT
	,@LogTypeId int
	,@AtmId int
	,@CardNo varchar(16)
	,@LogDate date
	,@Amount decimal(20)
	,@Details varchar(100)

AS

	INSERT INTO [Log]
	(
		[LogTypeId],
		[AtmId],
		[CardNo],
		[LogDate],
		[Amount],
		[Details]
	)
	VALUES
	(
		@LogTypeId,
		@AtmId,
		@CardNo,
		@LogDate,
		@Amount,
		@Details
	)
	SELECT
		@LogId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Log_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_Update]
GO

/* Procedure sproc_Log_Update*/
CREATE PROCEDURE sproc_Log_Update
	@LogTypeId int,
	@AtmId int,
	@CardNo varchar(16),
	@LogDate date,
	@Amount decimal(20),
	@Details varchar(100),
	@LogId int

AS
UPDATE [Log]
SET
	[LogTypeId] = @LogTypeId,
	[AtmId] = @AtmId,
	[CardNo] = @CardNo,
	[LogDate] = @LogDate,
	[Amount] = @Amount,
	[Details] = @Details
WHERE
	[LogId] = @LogId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Log_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Log_Delete]
GO

/* Procedure sproc_Log_Delete*/
CREATE PROCEDURE sproc_Log_Delete
	@LogId int
AS
DELETE
FROM
	[Log]
WHERE
	[LogId] = @LogId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_GetCount]
GO

/* Procedure sproc_LogType_GetCount*/
CREATE PROCEDURE sproc_LogType_GetCount
AS
SELECT
	COUNT(*)
FROM
	[LogType]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_Get]
GO

/* Procedure sproc_LogType_Get*/
CREATE PROCEDURE sproc_LogType_Get
AS
SELECT
	--[LogTypeId],
	--[Description]

*
FROM
	[LogType]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_GetByLogTypeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_GetByLogTypeId]
GO

/* Procedure sproc_LogType_GetByLogTypeId*/
CREATE PROCEDURE sproc_LogType_GetByLogTypeId
@LogTypeId int
AS
SELECT
	--[LogTypeId],
	--[Description]

*
FROM
	[LogType]
WHERE
	[LogTypeId] = @LogTypeId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_GetPaged]
GO

/* Procedure sproc_LogType_GetPaged*/
CREATE PROCEDURE sproc_LogType_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [LogTypeId]
FROM [LogType]


-- query out
SELECT *
FROM [LogType]
WHERE [LogTypeId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_Add]
GO

/* Procedure sproc_LogType_Add*/
CREATE PROCEDURE sproc_LogType_Add
	@LogTypeId int OUTPUT
	,@Description nvarchar(100)

AS

	INSERT INTO [LogType]
	(
		[Description]
	)
	VALUES
	(
		@Description
	)
	SELECT
		@LogTypeId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_Update]
GO

/* Procedure sproc_LogType_Update*/
CREATE PROCEDURE sproc_LogType_Update
	@Description nvarchar(100),
	@LogTypeId int

AS
UPDATE [LogType]
SET
	[Description] = @Description
WHERE
	[LogTypeId] = @LogTypeId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_LogType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_LogType_Delete]
GO

/* Procedure sproc_LogType_Delete*/
CREATE PROCEDURE sproc_LogType_Delete
	@LogTypeId int
AS
DELETE
FROM
	[LogType]
WHERE
	[LogTypeId] = @LogTypeId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Money_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_GetCount]
GO

/* Procedure sproc_Money_GetCount*/
CREATE PROCEDURE sproc_Money_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Money]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Money_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_Get]
GO

/* Procedure sproc_Money_Get*/
CREATE PROCEDURE sproc_Money_Get
AS
SELECT
	--[MoneyId],
	--[MoneyValue],
	--[Address]

*
FROM
	[Money]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Money_GetByMoneyId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_GetByMoneyId]
GO

/* Procedure sproc_Money_GetByMoneyId*/
CREATE PROCEDURE sproc_Money_GetByMoneyId
@MoneyId int
AS
SELECT
	--[MoneyId],
	--[MoneyValue],
	--[Address]

*
FROM
	[Money]
WHERE
	[MoneyId] = @MoneyId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Money_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_GetPaged]
GO

/* Procedure sproc_Money_GetPaged*/
CREATE PROCEDURE sproc_Money_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [MoneyId]
FROM [Money]


-- query out
SELECT *
FROM [Money]
WHERE [MoneyId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Money_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_Add]
GO

/* Procedure sproc_Money_Add*/
CREATE PROCEDURE sproc_Money_Add
	@MoneyId int OUTPUT
	,@MoneyValue decimal(20)
	,@Address nvarchar(100)

AS

	INSERT INTO [Money]
	(
		[MoneyValue],
		[Address]
	)
	VALUES
	(
		@MoneyValue,
		@Address
	)
	SELECT
		@MoneyId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Money_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_Update]
GO

/* Procedure sproc_Money_Update*/
CREATE PROCEDURE sproc_Money_Update
	@MoneyValue decimal(20),
	@Address nvarchar(100),
	@MoneyId int

AS
UPDATE [Money]
SET
	[MoneyValue] = @MoneyValue,
	[Address] = @Address
WHERE
	[MoneyId] = @MoneyId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Money_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Money_Delete]
GO

/* Procedure sproc_Money_Delete*/
CREATE PROCEDURE sproc_Money_Delete
	@MoneyId int
AS
DELETE
FROM
	[Money]
WHERE
	[MoneyId] = @MoneyId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_GetCount]
GO

/* Procedure sproc_OverDraft_GetCount*/
CREATE PROCEDURE sproc_OverDraft_GetCount
AS
SELECT
	COUNT(*)
FROM
	[OverDraft]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_Get]
GO

/* Procedure sproc_OverDraft_Get*/
CREATE PROCEDURE sproc_OverDraft_Get
AS
SELECT
	--[OdId],
	--[Value]

*
FROM
	[OverDraft]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_GetByOdId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_GetByOdId]
GO

/* Procedure sproc_OverDraft_GetByOdId*/
CREATE PROCEDURE sproc_OverDraft_GetByOdId
@OdId int
AS
SELECT
	--[OdId],
	--[Value]

*
FROM
	[OverDraft]
WHERE
	[OdId] = @OdId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_GetPaged]
GO

/* Procedure sproc_OverDraft_GetPaged*/
CREATE PROCEDURE sproc_OverDraft_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [OdId]
FROM [OverDraft]


-- query out
SELECT *
FROM [OverDraft]
WHERE [OdId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_Add]
GO

/* Procedure sproc_OverDraft_Add*/
CREATE PROCEDURE sproc_OverDraft_Add
	@OdId int OUTPUT
	,@Value varchar(50)

AS

	INSERT INTO [OverDraft]
	(
		[Value]
	)
	VALUES
	(
		@Value
	)
	SELECT
		@OdId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_Update]
GO

/* Procedure sproc_OverDraft_Update*/
CREATE PROCEDURE sproc_OverDraft_Update
	@Value varchar(50),
	@OdId int

AS
UPDATE [OverDraft]
SET
	[Value] = @Value
WHERE
	[OdId] = @OdId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_OverDraft_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_OverDraft_Delete]
GO

/* Procedure sproc_OverDraft_Delete*/
CREATE PROCEDURE sproc_OverDraft_Delete
	@OdId int
AS
DELETE
FROM
	[OverDraft]
WHERE
	[OdId] = @OdId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_GetCount]
GO

/* Procedure sproc_Stock_GetCount*/
CREATE PROCEDURE sproc_Stock_GetCount
AS
SELECT
	COUNT(*)
FROM
	[Stock]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_Get]
GO

/* Procedure sproc_Stock_Get*/
CREATE PROCEDURE sproc_Stock_Get
AS
SELECT
	--[StockId],
	--[MoneyId],
	--[AtmId],
	--[QuanlityId]

*
FROM
	[Stock]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_GetByStockId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_GetByStockId]
GO

/* Procedure sproc_Stock_GetByStockId*/
CREATE PROCEDURE sproc_Stock_GetByStockId
@StockId int
AS
SELECT
	--[StockId],
	--[MoneyId],
	--[AtmId],
	--[QuanlityId]

*
FROM
	[Stock]
WHERE
	[StockId] = @StockId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_GetPaged]
GO

/* Procedure sproc_Stock_GetPaged*/
CREATE PROCEDURE sproc_Stock_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [StockId]
FROM [Stock]


-- query out
SELECT *
FROM [Stock]
WHERE [StockId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_Add]
GO

/* Procedure sproc_Stock_Add*/
CREATE PROCEDURE sproc_Stock_Add
	@StockId int OUTPUT
	,@MoneyId int
	,@AtmId int
	,@QuanlityId int

AS

	INSERT INTO [Stock]
	(
		[MoneyId],
		[AtmId],
		[QuanlityId]
	)
	VALUES
	(
		@MoneyId,
		@AtmId,
		@QuanlityId
	)
	SELECT
		@StockId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_Update]
GO

/* Procedure sproc_Stock_Update*/
CREATE PROCEDURE sproc_Stock_Update
	@MoneyId int,
	@AtmId int,
	@QuanlityId int,
	@StockId int

AS
UPDATE [Stock]
SET
	[MoneyId] = @MoneyId,
	[AtmId] = @AtmId,
	[QuanlityId] = @QuanlityId
WHERE
	[StockId] = @StockId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_Stock_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_Stock_Delete]
GO

/* Procedure sproc_Stock_Delete*/
CREATE PROCEDURE sproc_Stock_Delete
	@StockId int
AS
DELETE
FROM
	[Stock]
WHERE
	[StockId] = @StockId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_GetCount]
GO

/* Procedure sproc_WithdrawLimit_GetCount*/
CREATE PROCEDURE sproc_WithdrawLimit_GetCount
AS
SELECT
	COUNT(*)
FROM
	[WithdrawLimit]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_Get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_Get]
GO

/* Procedure sproc_WithdrawLimit_Get*/
CREATE PROCEDURE sproc_WithdrawLimit_Get
AS
SELECT
	--[WdId],
	--[Value]

*
FROM
	[WithdrawLimit]
GO


if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_GetByWdId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_GetByWdId]
GO

/* Procedure sproc_WithdrawLimit_GetByWdId*/
CREATE PROCEDURE sproc_WithdrawLimit_GetByWdId
@WdId int
AS
SELECT
	--[WdId],
	--[Value]

*
FROM
	[WithdrawLimit]
WHERE
	[WdId] = @WdId
GO



if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_GetPaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_GetPaged]
GO

/* Procedure sproc_WithdrawLimit_GetPaged*/
CREATE PROCEDURE sproc_WithdrawLimit_GetPaged
	@RecPerPage INT,
	@PageIndex INT
AS

DECLARE @FirstRec INT
DECLARE @LastRec INT

SET @FirstRec = (@PageIndex - 1)*@RecPerPage + 1
SET @LastRec = @PageIndex *@RecPerPage 

-- create temp table to paging
CREATE TABLE #tmp_paging_index
(
	recID		INT IDENTITY(1,1) NOT NULL,
	messageID	int
)

-- insert temp records
INSERT INTO #tmp_paging_index(messageID)
SELECT [WdId]
FROM [WithdrawLimit]


-- query out
SELECT *
FROM [WithdrawLimit]
WHERE [WdId]
IN (
	SELECT messageID 
	FROM #tmp_paging_index 
	WHERE recID >= @FirstRec AND recID <= @LastRec
)
DROP TABLE #tmp_paging_index

GO



if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_Add]
GO

/* Procedure sproc_WithdrawLimit_Add*/
CREATE PROCEDURE sproc_WithdrawLimit_Add
	@WdId int OUTPUT
	,@Value varchar(50)

AS

	INSERT INTO [WithdrawLimit]
	(
		[Value]
	)
	VALUES
	(
		@Value
	)
	SELECT
		@WdId = @@Identity

GO
if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_Update]
GO

/* Procedure sproc_WithdrawLimit_Update*/
CREATE PROCEDURE sproc_WithdrawLimit_Update
	@Value varchar(50),
	@WdId int

AS
UPDATE [WithdrawLimit]
SET
	[Value] = @Value
WHERE
	[WdId] = @WdId
GO

if exists (select * from sysobjects where id = object_id(N'[sproc_WithdrawLimit_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [sproc_WithdrawLimit_Delete]
GO

/* Procedure sproc_WithdrawLimit_Delete*/
CREATE PROCEDURE sproc_WithdrawLimit_Delete
	@WdId int
AS
DELETE
FROM
	[WithdrawLimit]
WHERE
	[WdId] = @WdId
GO

