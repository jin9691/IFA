USE MASTER
GO

IF EXISTS (SELECT name FROM sysdatabases  WHERE name = N'INSTITUTE_OF_FINE_ART')
DROP DATABASE INSTITUTE_OF_FINE_ART
GO

CREATE DATABASE INSTITUTE_OF_FINE_ART
GO

USE INSTITUTE_OF_FINE_ART
GO

CREATE TABLE [Users](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Username] VARCHAR(30) UNIQUE ,
	[Password] VARCHAR(50),
	[Email] VARCHAR(50) UNIQUE ,
	[Name] NVARCHAR(50),
	[Address] NVARCHAR(50),
	[Gender] BIT DEFAULT 0,
	[Birthday] DATETIME,
	[Phone] VARCHAR(15),
	[Permission] TINYINT DEFAULT 0,
)
GO

CREATE TABLE [Exhibitions]
(
    [Id] INT IDENTITY(0, 1) PRIMARY KEY,
    [ManagerId] INT FOREIGN KEY([ManagerId]) REFERENCES [Users]([Id]),
    [ExhibitionName] NVARCHAR(50) UNIQUE ,
    [StartDate] DATETIME ,
    [EndDate] DATETIME ,
    [ExhibitionDescription] NTEXT ,
)
GO
INSERT INTO Exhibitions (ExhibitionName) VALUES ('NOT SELECT')
GO

CREATE TABLE [Competitions]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [StaffId] INT FOREIGN KEY([StaffId]) REFERENCES [Users]([Id]),
    [Topic] NVARCHAR(200) UNIQUE,
    [StartDate] DATETIME,
    [DueDate] DATETIME, 
    [CompetitionDescription] NTEXT, -- gioi thieu ve cuoc thi
    [Condition] NTEXT, -- dieu kien de tham gia cuoc thi nay
    [Remark] NTEXT, -- danh gia cua ban to chuc ve cuoc thi
)
GO

CREATE TABLE [Customers](
	[Id] INT IDENTITY(0,1) PRIMARY KEY,
	[CustomerEmail] VARCHAR(50),
	[CustomerName] NVARCHAR(50),
	[CustomerAddress] NVARCHAR(50),
	[CustomerGender] BIT DEFAULT 0,
	[CustomerBirthday] DATETIME,
	[CustomerPhone] VARCHAR(15),
)
GO
INSERT INTO Customers (CustomerName) VALUES ('NOT SELECT')
GO

CREATE  TABLE   [Paintings]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [PaintingDescription] NTEXT,
    [PaintingURL] NVARCHAR(100),
	[Mark] TINYINT,
    [UploadDate] DATETIME DEFAULT GETDATE(),
    [LastModify] DATETIME DEFAULT GETDATE(),
    [CompetitionId] INT FOREIGN KEY([CompetitionId]) REFERENCES [Competitions]([Id]),
    [StudentId] INT FOREIGN KEY([StudentId]) REFERENCES [Users]([Id]),
    [ExhibitionId] INT FOREIGN KEY([ExhibitionId]) REFERENCES [Exhibitions]([Id]),
    [CustomerId] INT FOREIGN KEY([CustomerId]) REFERENCES [Customers]([Id]),
    [Comment] NTEXT, -- comment from teacher
    [IsExhibited] BIT, -- 1 if exhibited, else 0
    [Price] INT, -- if this painting has exhibited, it's must be set the price
    [IsPaid] BIT ,-- 1 if paid , else 0
)
GO

CREATE  TABLE [Awards]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [AwardName] NVARCHAR(50),
    [AwardRank] NVARCHAR(100),
    [AwardDescription] NTEXT ,  
    [PaintingId] INT FOREIGN KEY([PaintingId]) REFERENCES [Paintings]([Id]), -- which is winner
    [CompetitionId] INT FOREIGN KEY([CompetitionId]) REFERENCES [Competitions]([Id])
)
GO
