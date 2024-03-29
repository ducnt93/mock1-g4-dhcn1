USE [DbMock1G4]
GO
/****** Object:  Table [dbo].[WithdrawLimit]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WithdrawLimit](
	[WdId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WITHDRAWLIMIT] PRIMARY KEY CLUSTERED 
(
	[WdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[WithdrawLimit] ON
INSERT [dbo].[WithdrawLimit] ([WdId], [Value]) VALUES (1, N'50000')
SET IDENTITY_INSERT [dbo].[WithdrawLimit] OFF
/****** Object:  Table [dbo].[OverDraft]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OverDraft](
	[OdId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OVERDRAFT] PRIMARY KEY CLUSTERED 
(
	[OdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[OverDraft] ON
INSERT [dbo].[OverDraft] ([OdId], [Value]) VALUES (1, N'20000')
SET IDENTITY_INSERT [dbo].[OverDraft] OFF
/****** Object:  Table [dbo].[Money]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Money](
	[MoneyId] [int] IDENTITY(1,1) NOT NULL,
	[MoneyValue] [decimal](18, 0) NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MONEY] PRIMARY KEY CLUSTERED 
(
	[MoneyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Money] ON
INSERT [dbo].[Money] ([MoneyId], [MoneyValue], [Address]) VALUES (1, CAST(500000 AS Decimal(18, 0)), N'Từ liêm - Hà nội')
INSERT [dbo].[Money] ([MoneyId], [MoneyValue], [Address]) VALUES (2, CAST(200000 AS Decimal(18, 0)), N'Từ liêm - Hà nội')
INSERT [dbo].[Money] ([MoneyId], [MoneyValue], [Address]) VALUES (3, CAST(100000 AS Decimal(18, 0)), N'Từ liêm - Hà nội')
INSERT [dbo].[Money] ([MoneyId], [MoneyValue], [Address]) VALUES (4, CAST(50000 AS Decimal(18, 0)), N'Từ liêm - Hà nội')
SET IDENTITY_INSERT [dbo].[Money] OFF
/****** Object:  Table [dbo].[LogType]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogType](
	[LogTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LOGTYPE] PRIMARY KEY CLUSTERED 
(
	[LogTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LogType] ON
INSERT [dbo].[LogType] ([LogTypeId], [Description]) VALUES (1, N'Log type 1')
INSERT [dbo].[LogType] ([LogTypeId], [Description]) VALUES (2, N'Log type 2')
SET IDENTITY_INSERT [dbo].[LogType] OFF
/****** Object:  Table [dbo].[Customer]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Addr] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[CusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT [dbo].[Customer] ([CusId], [Name], [Phone], [Email], [Addr]) VALUES (1, N'Nguyễn Trung Đức', N'01685042849', N'ducnt.ts24@gmail.com', N'Sóc Sơn - Hà Nội')
INSERT [dbo].[Customer] ([CusId], [Name], [Phone], [Email], [Addr]) VALUES (2, N'Nguyễn Văn Đức', N'01685555555', N'anhtrungduc1993@gmail.com', N'Sóc sơn - Hà Nội')
INSERT [dbo].[Customer] ([CusId], [Name], [Phone], [Email], [Addr]) VALUES (3, N'Hoàng Minh', N'123456789', N'minhhv@gmail.com', N'Đông Anh - Hà Nội')
SET IDENTITY_INSERT [dbo].[Customer] OFF
/****** Object:  Table [dbo].[Config]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[DateModified] [datetime] NULL,
	[MinWithdraw] [decimal](18, 0) NULL,
	[MaxWithdraw] [decimal](18, 0) NULL,
	[NumPerPage] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Config] ([DateModified], [MinWithdraw], [MaxWithdraw], [NumPerPage]) VALUES (CAST(0x0000A2C600000000 AS DateTime), CAST(1 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1)
/****** Object:  Table [dbo].[Atm]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atm](
	[AtmId] [int] IDENTITY(1,1) NOT NULL,
	[Branch] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ATM] PRIMARY KEY CLUSTERED 
(
	[AtmId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Atm] ON
INSERT [dbo].[Atm] ([AtmId], [Branch], [Address]) VALUES (1, N'Hà Nội', N'Từ liêm - Hà nội')
SET IDENTITY_INSERT [dbo].[Atm] OFF
/****** Object:  Table [dbo].[Account]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[CusId] [int] NULL,
	[AccountNo] [varchar](50) NOT NULL,
	[OdId] [int] NULL,
	[WdId] [int] NULL,
	[Balance] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON
INSERT [dbo].[Account] ([AccountId], [CusId], [AccountNo], [OdId], [WdId], [Balance]) VALUES (2, 1, N'123456', 1, 1, CAST(91910000 AS Decimal(18, 0)))
INSERT [dbo].[Account] ([AccountId], [CusId], [AccountNo], [OdId], [WdId], [Balance]) VALUES (4, 2, N'123456', 1, 1, CAST(5740000 AS Decimal(18, 0)))
INSERT [dbo].[Account] ([AccountId], [CusId], [AccountNo], [OdId], [WdId], [Balance]) VALUES (5, 3, N'123456', 1, 1, CAST(6580000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Account] OFF
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_Update*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_Update]
	@Value varchar(50),
	@OdId int

AS
UPDATE [OverDraft]
SET
	[Value] = @Value
WHERE
	[OdId] = @OdId
GO
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_GetCount*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[OverDraft]
GO
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_GetByOdId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_GetByOdId*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_GetByOdId]
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
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_Get*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_Get]
AS
SELECT
	--[OdId],
	--[Value]

*
FROM
	[OverDraft]
GO
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_Delete*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_Delete]
	@OdId int
AS
DELETE
FROM
	[OverDraft]
WHERE
	[OdId] = @OdId
GO
/****** Object:  StoredProcedure [dbo].[sproc_OverDraft_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_OverDraft_Add*/
CREATE PROCEDURE [dbo].[sproc_OverDraft_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Money_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_Update*/
CREATE PROCEDURE [dbo].[sproc_Money_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Money_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Money_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_Money_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Money_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Money]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Money_GetByMoneyId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_GetByMoneyId*/
CREATE PROCEDURE [dbo].[sproc_Money_GetByMoneyId]
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
/****** Object:  StoredProcedure [dbo].[sproc_Money_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_Get*/
CREATE PROCEDURE [dbo].[sproc_Money_Get]
AS
SELECT
	--[MoneyId],
	--[MoneyValue],
	--[Address]

*
FROM
	[Money]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Money_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_Delete*/
CREATE PROCEDURE [dbo].[sproc_Money_Delete]
	@MoneyId int
AS
DELETE
FROM
	[Money]
WHERE
	[MoneyId] = @MoneyId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Money_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Money_Add*/
CREATE PROCEDURE [dbo].[sproc_Money_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_LogType_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_Update*/
CREATE PROCEDURE [dbo].[sproc_LogType_Update]
	@Description nvarchar(100),
	@LogTypeId int

AS
UPDATE [LogType]
SET
	[Description] = @Description
WHERE
	[LogTypeId] = @LogTypeId
GO
/****** Object:  StoredProcedure [dbo].[sproc_LogType_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_LogType_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_LogType_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_GetCount*/
CREATE PROCEDURE [dbo].[sproc_LogType_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[LogType]
GO
/****** Object:  StoredProcedure [dbo].[sproc_LogType_GetByLogTypeId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_GetByLogTypeId*/
CREATE PROCEDURE [dbo].[sproc_LogType_GetByLogTypeId]
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
/****** Object:  StoredProcedure [dbo].[sproc_LogType_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_Get*/
CREATE PROCEDURE [dbo].[sproc_LogType_Get]
AS
SELECT
	--[LogTypeId],
	--[Description]

*
FROM
	[LogType]
GO
/****** Object:  StoredProcedure [dbo].[sproc_LogType_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_Delete*/
CREATE PROCEDURE [dbo].[sproc_LogType_Delete]
	@LogTypeId int
AS
DELETE
FROM
	[LogType]
WHERE
	[LogTypeId] = @LogTypeId
GO
/****** Object:  StoredProcedure [dbo].[sproc_LogType_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_LogType_Add*/
CREATE PROCEDURE [dbo].[sproc_LogType_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Customer_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_Update*/
CREATE PROCEDURE [dbo].[sproc_Customer_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Customer_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Customer_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_Customer_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Customer_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Customer]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Customer_GetByCusId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_GetByCusId*/
CREATE PROCEDURE [dbo].[sproc_Customer_GetByCusId]
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
/****** Object:  StoredProcedure [dbo].[sproc_Customer_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_Get*/
CREATE PROCEDURE [dbo].[sproc_Customer_Get]
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
/****** Object:  StoredProcedure [dbo].[sproc_Customer_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_Delete*/
CREATE PROCEDURE [dbo].[sproc_Customer_Delete]
	@CusId int
AS
DELETE
FROM
	[Customer]
WHERE
	[CusId] = @CusId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Customer_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Customer_Add*/
CREATE PROCEDURE [dbo].[sproc_Customer_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Config_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Config_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Config_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Config]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Config_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Config_Get*/
CREATE PROCEDURE [dbo].[sproc_Config_Get]
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
/****** Object:  StoredProcedure [dbo].[sproc_Config_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Config_Add*/
CREATE PROCEDURE [dbo].[sproc_Config_Add]
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
/****** Object:  Table [dbo].[Stock]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[MoneyId] [int] NULL,
	[AtmId] [int] NULL,
	[QuanlityId] [int] NOT NULL,
 CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Stock] ON
INSERT [dbo].[Stock] ([StockId], [MoneyId], [AtmId], [QuanlityId]) VALUES (1, 1, 1, 19)
INSERT [dbo].[Stock] ([StockId], [MoneyId], [AtmId], [QuanlityId]) VALUES (2, 2, 1, 84)
INSERT [dbo].[Stock] ([StockId], [MoneyId], [AtmId], [QuanlityId]) VALUES (3, 3, 1, 149)
INSERT [dbo].[Stock] ([StockId], [MoneyId], [AtmId], [QuanlityId]) VALUES (4, 4, 1, 193)
SET IDENTITY_INSERT [dbo].[Stock] OFF
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_Update*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_Update]
	@Value varchar(50),
	@WdId int

AS
UPDATE [WithdrawLimit]
SET
	[Value] = @Value
WHERE
	[WdId] = @WdId
GO
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_GetCount*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[WithdrawLimit]
GO
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_GetByWdId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_GetByWdId*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_GetByWdId]
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
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_Get*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_Get]
AS
SELECT
	--[WdId],
	--[Value]

*
FROM
	[WithdrawLimit]
GO
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_Delete*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_Delete]
	@WdId int
AS
DELETE
FROM
	[WithdrawLimit]
WHERE
	[WdId] = @WdId
GO
/****** Object:  StoredProcedure [dbo].[sproc_WithdrawLimit_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_WithdrawLimit_Add*/
CREATE PROCEDURE [dbo].[sproc_WithdrawLimit_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Atm_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_Update*/
CREATE PROCEDURE [dbo].[sproc_Atm_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Atm_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Atm_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_Atm_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Atm_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Atm]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Atm_GetByAtmId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_GetByAtmId*/
CREATE PROCEDURE [dbo].[sproc_Atm_GetByAtmId]
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
/****** Object:  StoredProcedure [dbo].[sproc_Atm_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_Get*/
CREATE PROCEDURE [dbo].[sproc_Atm_Get]
AS
SELECT
	--[AtmId],
	--[Branch],
	--[Address]

*
FROM
	[Atm]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Atm_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_Delete*/
CREATE PROCEDURE [dbo].[sproc_Atm_Delete]
	@AtmId int
AS
DELETE
FROM
	[Atm]
WHERE
	[AtmId] = @AtmId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Atm_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Atm_Add*/
CREATE PROCEDURE [dbo].[sproc_Atm_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Account_UpdateBalance]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sproc_Account_UpdateBalance]
	@Balance decimal(20),
	@AccountId int

AS
UPDATE [Account]
SET
	[Balance] = @Balance
WHERE
	[AccountId] = @AccountId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Account_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_Update*/
CREATE PROCEDURE [dbo].[sproc_Account_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Account_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Account_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_Account_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Account_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Account]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Account_GetByAccountId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_GetByAccountId*/
CREATE PROCEDURE [dbo].[sproc_Account_GetByAccountId]
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
/****** Object:  StoredProcedure [dbo].[sproc_Account_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_Get*/
CREATE PROCEDURE [dbo].[sproc_Account_Get]
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
/****** Object:  StoredProcedure [dbo].[sproc_Account_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_Delete*/
CREATE PROCEDURE [dbo].[sproc_Account_Delete]
	@AccountId int
AS
DELETE
FROM
	[Account]
WHERE
	[AccountId] = @AccountId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Account_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Account_Add*/
CREATE PROCEDURE [dbo].[sproc_Account_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Stock_UpdateQuantity]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sproc_Stock_UpdateQuantity]
	@QuanlityId int,
	@StockId int

AS
UPDATE [Stock]
SET
	[QuanlityId] = @QuanlityId
WHERE
	[StockId] = @StockId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Stock_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_Update*/
CREATE PROCEDURE [dbo].[sproc_Stock_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Stock_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Stock_GetPaged]
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
/****** Object:  StoredProcedure [dbo].[sproc_Stock_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Stock_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Stock]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Stock_GetByStockId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_GetByStockId*/
CREATE PROCEDURE [dbo].[sproc_Stock_GetByStockId]
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
/****** Object:  StoredProcedure [dbo].[sproc_Stock_GetByAtmIdAndStockId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sproc_Stock_GetByAtmIdAndStockId]
@AtmId int,
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
	AtmId = @AtmId and StockId = @StockId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Stock_GetByAtmId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sproc_Stock_GetByAtmId]
@AtmId int
AS
SELECT
	[StockId],
	s.[MoneyId],
	[AtmId],
	[QuanlityId]
FROM
	[Stock] s, [Money] m
WHERE
s.MoneyId = m.MoneyId and
	s.AtmId = @AtmId
	order by m.MoneyValue desc
GO
/****** Object:  StoredProcedure [dbo].[sproc_Stock_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_Get*/
CREATE PROCEDURE [dbo].[sproc_Stock_Get]
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
/****** Object:  StoredProcedure [dbo].[sproc_Stock_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_Delete*/
CREATE PROCEDURE [dbo].[sproc_Stock_Delete]
	@StockId int
AS
DELETE
FROM
	[Stock]
WHERE
	[StockId] = @StockId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Stock_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Stock_Add*/
CREATE PROCEDURE [dbo].[sproc_Stock_Add]
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
/****** Object:  Table [dbo].[Card]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Card](
	[CardNo] [varchar](16) NOT NULL,
	[Status] [varchar](30) NOT NULL,
	[AccountId] [int] NULL,
	[Pin] [varchar](6) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[ExpiredDate] [datetime] NOT NULL,
	[Attempt] [int] NOT NULL,
 CONSTRAINT [PK_CARD] PRIMARY KEY CLUSTERED 
(
	[CardNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Card] ([CardNo], [Status], [AccountId], [Pin], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'1', N'UnBlock', 2, N'1', CAST(0x0000A2C600000000 AS DateTime), CAST(0x0000A2C600000000 AS DateTime), 0)
INSERT [dbo].[Card] ([CardNo], [Status], [AccountId], [Pin], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'12', N'UnBlock', 2, N'1', CAST(0x0000A2C600000000 AS DateTime), CAST(0x0000A9C900000000 AS DateTime), 0)
INSERT [dbo].[Card] ([CardNo], [Status], [AccountId], [Pin], [StartDate], [ExpiredDate], [Attempt]) VALUES (N'1234567890', N'UnBlock', 2, N'1', CAST(0x0000A2A700000000 AS DateTime), CAST(0x0000A9C900000000 AS DateTime), 0)
/****** Object:  Table [dbo].[Log]    Script Date: 09/09/2014 17:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeId] [int] NULL,
	[AtmId] [int] NULL,
	[CardNo] [varchar](16) NULL,
	[LogDate] [datetime] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[Details] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LOG] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (70, 2, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(20000 AS Decimal(18, 0)), N'4')
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (71, 2, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(50000 AS Decimal(18, 0)), N'5')
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (72, 1, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'')
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (73, 1, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'')
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (74, 2, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(20000 AS Decimal(18, 0)), N'4')
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (75, 1, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(1000000 AS Decimal(18, 0)), N'')
INSERT [dbo].[Log] ([LogId], [LogTypeId], [AtmId], [CardNo], [LogDate], [Amount], [Details]) VALUES (76, 1, 1, N'1234567890', CAST(0x0000A3A100000000 AS DateTime), CAST(500000 AS Decimal(18, 0)), N'')
SET IDENTITY_INSERT [dbo].[Log] OFF
/****** Object:  StoredProcedure [dbo].[sproc_Card_UpdateStatus]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_UpdateStatus*/
CREATE PROCEDURE [dbo].[sproc_Card_UpdateStatus]
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
/****** Object:  StoredProcedure [dbo].[sproc_Card_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_Update*/
CREATE PROCEDURE [dbo].[sproc_Card_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Card_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Card_GetPaged]
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
	CONVERT(varchar(1000),HASHBYTES('MD5', Pin),2) as Pin,
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
/****** Object:  StoredProcedure [dbo].[sproc_Card_GetHashPIN]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_GetHashPIN*/
CREATE PROCEDURE [dbo].[sproc_Card_GetHashPIN]
@CardNo varchar(16)
AS
SELECT
	CONVERT(varchar(1000),HASHBYTES('MD5', Pin),2) as Pin
FROM
	[Card]
WHERE
	[CardNo] = @CardNo
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Card_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Card]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_GetCardNo]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_GetByCardNo*/
CREATE PROCEDURE [dbo].[sproc_Card_GetCardNo]
@CardNo varchar(16)
AS
SELECT
	[CardNo]
FROM
	[Card]
WHERE
	[CardNo] =@CardNo
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_GetByCardNoPIN]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_GetByCardNoPIN*/
CREATE PROCEDURE [dbo].[sproc_Card_GetByCardNoPIN]
@CardNo varchar(16),
@HashPin varchar(1000)
AS
SELECT
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(1000),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM
	[Card]
WHERE
	[CardNo] =@CardNo AND CONVERT(varchar(1000),HASHBYTES('MD5', Pin),2) = @HashPin
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_GetByCardNo]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_GetByCardNo*/
CREATE PROCEDURE [dbo].[sproc_Card_GetByCardNo]
@CardNo varchar(16)
AS
SELECT
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(1000),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM
	[Card]
WHERE
	[CardNo] = @CardNo
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_Get*/
CREATE PROCEDURE [dbo].[sproc_Card_Get]
AS
SELECT
	[CardNo],
	[Status],
	[AccountId],
	CONVERT(varchar(1000),HASHBYTES('MD5', Pin),2) as Pin,
	[StartDate],
	[ExpiredDate],
	[Attempt]
FROM
	[Card]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_Delete*/
CREATE PROCEDURE [dbo].[sproc_Card_Delete]
	@CardNo varchar(16)
AS
DELETE
FROM
	[Card]
WHERE
	[CardNo] = @CardNo
GO
/****** Object:  StoredProcedure [dbo].[sproc_Card_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Card_Add*/
CREATE PROCEDURE [dbo].[sproc_Card_Add]
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
/****** Object:  StoredProcedure [dbo].[sproc_Log_Update]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_Update*/
CREATE PROCEDURE [dbo].[sproc_Log_Update]
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
/****** Object:  StoredProcedure [dbo].[sproc_Log_GetPaged]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_GetPaged*/
CREATE PROCEDURE [dbo].[sproc_Log_GetPaged]
	@Time INT,
	@CardNo varchar(16)
AS
-- query out
IF(@Time=7)
(
	SELECT  a.[Address], lt.[Description] , l.LogDate, l.Amount,l.Details
	FROM [Log] l INNER JOIN Atm a
	ON l.AtmId=a.AtmId
	INNER JOIN LogType lt
	ON lt.LogTypeId=l.LogTypeId
	INNER JOIN Card 
	ON Card.CardNo=l.CardNo
	WHERE (@CardNo=l.CardNo) and (datediff(DD,LogDate,GETDATE()))<=7	
)
IF(@Time=30)
(
SELECT  a.[Address], lt.[Description] , l.LogDate, l.Amount,l.Details
	FROM [Log] l INNER JOIN Atm a
	ON l.AtmId=a.AtmId
	INNER JOIN LogType lt
	ON lt.LogTypeId=l.LogTypeId
	INNER JOIN Card 
	ON Card.CardNo=l.CardNo
	WHERE (@CardNo=l.CardNo) and (datediff(DD,LogDate,GETDATE()))<=30			
)
IF(@Time=120)
(
SELECT  a.[Address], lt.[Description] , l.LogDate, l.Amount,l.Details
	FROM [Log] l INNER JOIN Atm a
	ON l.AtmId=a.AtmId
	INNER JOIN LogType lt
	ON lt.LogTypeId=l.LogTypeId
	INNER JOIN Card 
	ON Card.CardNo=l.CardNo
	WHERE (@CardNo=l.CardNo) and (datediff(DD,LogDate,GETDATE()))<=120			
)
IF(@Time=180)
(
SELECT  a.[Address], lt.[Description] , l.LogDate, l.Amount,l.Details
	FROM [Log] l INNER JOIN Atm a
	ON l.AtmId=a.AtmId
	INNER JOIN LogType lt
	ON lt.LogTypeId=l.LogTypeId
	INNER JOIN Card 
	ON Card.CardNo=l.CardNo
	WHERE (@CardNo=l.CardNo) and (datediff(DD,LogDate,GETDATE()))<=180			
)
IF(@Time=365)
(
SELECT  a.[Address], lt.[Description] , l.LogDate, l.Amount,l.Details
	FROM [Log] l INNER JOIN Atm a
	ON l.AtmId=a.AtmId
	INNER JOIN LogType lt
	ON lt.LogTypeId=l.LogTypeId
	INNER JOIN Card 
	ON Card.CardNo=l.CardNo
	WHERE (@CardNo=l.CardNo) and (datediff(DD,LogDate,GETDATE()))<=365
	
	--(datepart(YY,GETDATE())-datepart(YY,LogDate))*365 + 
	--		(datepart(MM,GETDATE())-datepart(MM,LogDate))*30 +
	--		(datepart(DD,GETDATE())-datepart(DD,LogDate))<=365			
)
IF(@Time=700)
(
SELECT  a.[Address], lt.[Description] , l.LogDate, l.Amount,l.Details
	FROM [Log] l INNER JOIN Atm a
	ON l.AtmId=a.AtmId
	INNER JOIN LogType lt
	ON lt.LogTypeId=l.LogTypeId
	INNER JOIN Card 
	ON Card.CardNo=l.CardNo
	WHERE (@CardNo=l.CardNo) and (datediff(DD,LogDate,GETDATE()))<=700						
)

EXEC [sproc_Log_GetPaged] 7,'1234567890'
GO
/****** Object:  StoredProcedure [dbo].[sproc_Log_GetCount]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_GetCount*/
CREATE PROCEDURE [dbo].[sproc_Log_GetCount]
AS
SELECT
	COUNT(*)
FROM
	[Log]
GO
/****** Object:  StoredProcedure [dbo].[sproc_Log_GetByLogId]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_GetByLogId*/
CREATE PROCEDURE [dbo].[sproc_Log_GetByLogId]
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
/****** Object:  StoredProcedure [dbo].[sproc_Log_Get]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_Get*/
CREATE PROCEDURE [dbo].[sproc_Log_Get]
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
/****** Object:  StoredProcedure [dbo].[sproc_Log_Delete]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_Delete*/
CREATE PROCEDURE [dbo].[sproc_Log_Delete]
	@LogId int
AS
DELETE
FROM
	[Log]
WHERE
	[LogId] = @LogId
GO
/****** Object:  StoredProcedure [dbo].[sproc_Log_Add]    Script Date: 09/09/2014 17:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Procedure sproc_Log_Add*/
CREATE PROCEDURE [dbo].[sproc_Log_Add]
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
/****** Object:  ForeignKey [FK_ACCOUNT_CUSTOMER]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNT_CUSTOMER] FOREIGN KEY([CusId])
REFERENCES [dbo].[Customer] ([CusId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_ACCOUNT_CUSTOMER]
GO
/****** Object:  ForeignKey [FK_ACCOUNT_OVERDRAFT]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNT_OVERDRAFT] FOREIGN KEY([OdId])
REFERENCES [dbo].[OverDraft] ([OdId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_ACCOUNT_OVERDRAFT]
GO
/****** Object:  ForeignKey [FK_ACCOUNT_WITHDRAWLIMIT]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNT_WITHDRAWLIMIT] FOREIGN KEY([WdId])
REFERENCES [dbo].[WithdrawLimit] ([WdId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_ACCOUNT_WITHDRAWLIMIT]
GO
/****** Object:  ForeignKey [FK_CARD_ACCOUNT]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_CARD_ACCOUNT] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_CARD_ACCOUNT]
GO
/****** Object:  ForeignKey [FK_LOG_ATM]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_LOG_ATM] FOREIGN KEY([AtmId])
REFERENCES [dbo].[Atm] ([AtmId])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_LOG_ATM]
GO
/****** Object:  ForeignKey [FK_LOG_CARD]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_LOG_CARD] FOREIGN KEY([CardNo])
REFERENCES [dbo].[Card] ([CardNo])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_LOG_CARD]
GO
/****** Object:  ForeignKey [FK_LOG_LOGTYPE]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_LOG_LOGTYPE] FOREIGN KEY([LogTypeId])
REFERENCES [dbo].[LogType] ([LogTypeId])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_LOG_LOGTYPE]
GO
/****** Object:  ForeignKey [FK_STOCK_ATM]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_STOCK_ATM] FOREIGN KEY([AtmId])
REFERENCES [dbo].[Atm] ([AtmId])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_STOCK_ATM]
GO
/****** Object:  ForeignKey [FK_STOCK_MONEY]    Script Date: 09/09/2014 17:52:29 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_STOCK_MONEY] FOREIGN KEY([MoneyId])
REFERENCES [dbo].[Money] ([MoneyId])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_STOCK_MONEY]
GO
