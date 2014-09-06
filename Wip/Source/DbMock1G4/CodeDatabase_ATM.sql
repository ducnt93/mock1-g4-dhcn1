-- =============================================
-- Create database template
-- =============================================
USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'DbMock1G4'
)
DROP DATABASE DbMock1G4_2 
GO

CREATE DATABASE DbMock1G4
GO

USE DbMock1G4
GO

CREATE TABLE dbo.Customer
(
	CusId	int identity(1,1),
	Name	nvarchar(100) NOT NULL,
	Phone	varchar(50),
	Email	varchar(100),
	Addr	nvarchar(200) NOT NULL,
	CONSTRAINT PK_CUSTOMER PRIMARY KEY (CusId)
)
GO

CREATE TABLE dbo.OverDraft
(
	OdId	int  identity(1,1),
	Value	varchar(50) NOT NULL,
	CONSTRAINT PK_OVERDRAFT PRIMARY KEY (OdId)
)
GO

CREATE TABLE dbo.WithdrawLimit
(
	WdId	int  identity(1,1),
	Value	varchar(50) NOT NULL,
	CONSTRAINT PK_WITHDRAWLIMIT PRIMARY KEY (WdId)
)
GO

CREATE TABLE dbo.Atm
(
	AtmId	int  identity(1,1),
	Branch	nvarchar(50) NOT NULL,
	Address nvarchar(100) NOT NULL,
	CONSTRAINT PK_ATM PRIMARY KEY (AtmId)
)
GO

CREATE TABLE dbo.LogType
(
	LogTypeId	int  identity(1,1),
	Description nvarchar(100) NOT NULL,
	CONSTRAINT PK_LOGTYPE PRIMARY KEY (LogTypeId)
)
GO

CREATE TABLE dbo.[Money]
(
	MoneyId		int identity(1,1),
	MoneyValue	Decimal,
	Address nvarchar(100) NOT NULL,
	CONSTRAINT PK_MONEY PRIMARY KEY (MoneyId)
)
GO

CREATE TABLE dbo.Account
(
	AccountId	int identity(1,1),
	CusId		int,
	AccountNo	varchar(50) NOT NULL,
	OdId		int,
	WdId		int,
	Balance		Decimal NOT NULL,
	CONSTRAINT PK_ACCOUNT PRIMARY KEY (AccountId),
	CONSTRAINT FK_ACCOUNT_CUSTOMER FOREIGN KEY (CusId) REFERENCES Customer(CusId),
	CONSTRAINT FK_ACCOUNT_OVERDRAFT FOREIGN KEY (OdId) REFERENCES OverDraft(OdId),
	CONSTRAINT FK_ACCOUNT_WITHDRAWLIMIT FOREIGN KEY (WdId) REFERENCES WithdrawLimit(WdId)	
)
GO

CREATE TABLE dbo.Stock
(
	StockId int identity(1,1),
	MoneyId int,
	AtmId	int,
	QuanlityId int NOT NULL,
	CONSTRAINT PK_STOCK PRIMARY KEY (StockId),
	CONSTRAINT FK_STOCK_ATM FOREIGN KEY (AtmId) REFERENCES Atm(AtmId),
	CONSTRAINT FK_STOCK_MONEY FOREIGN KEY (MoneyId) REFERENCES Money(MoneyId)	
)
GO

CREATE TABLE dbo.[Card]
(
	CardNo		varchar(16),
	Status		varchar(30) NOT NULL,
	AccountId	int,
	Pin			varchar(6) NOT NULL,
	StartDate	date NOT NULL,
	ExpiredDate date NOT NULL,
	Attempt		int NOT NULL,	
	CONSTRAINT PK_CARD PRIMARY KEY (CardNo),
	CONSTRAINT FK_CARD_ACCOUNT FOREIGN KEY (AccountId) REFERENCES Account(AccountId)
)
GO

CREATE TABLE dbo.[Log]
(
	LogId int identity(1,1),
	LogTypeId int,
	AtmId int,
	CardNo varchar(16),
	LogDate date NOT NULL,
	Amount decimal NOT NULL,
	Details varchar(100) NOT NULL,
	CONSTRAINT PK_LOG PRIMARY KEY (LogId),
	CONSTRAINT FK_LOG_ATM FOREIGN KEY (AtmId) REFERENCES Atm(AtmId),
	CONSTRAINT FK_LOG_LOGTYPE FOREIGN KEY (LogTypeId) REFERENCES LogType(LogTypeId),
	CONSTRAINT FK_LOG_CARD FOREIGN KEY (CardNo) REFERENCES Card(CardNo),
)
GO

CREATE TABLE dbo.Config
(
	DateModified date,
	MinWithdraw decimal,
	MaxWithdraw decimal,
	NumPerPage int,	
)
GO