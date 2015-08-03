IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'ATM')
  CREATE DATABASE ATM
GO

USE ATM
GO

IF OBJECT_ID('CardAccounts') IS NOT NULL
  DROP TABLE CardAccounts

CREATE TABLE CardAccounts(
	Id int IDENTITY not null,
	CardNumber nvarchar(10),
	CardPin nvarchar (4),
	CardCash money
	CONSTRAINT PK_CardAccounts PRIMARY KEY (Id)
	)
GO

INSERT CardAccounts(CardNumber, CardPin, CardCash)
VALUES
	(848484, 8181, 200),
	(737161, 1234, 500),
	(987262, 7162, 400)
GO