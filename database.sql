USE MASTER
GO

ALTER DATABASE [INSTITUTE_OF_FINE_ART] SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
GO
DROP DATABASE [INSTITUTE_OF_FINE_ART]
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
	[Id] INT IDENTITY(0, 1) PRIMARY KEY,
	[CustomerEmail] VARCHAR(50),
	[CustomerName] NVARCHAR(50),
	[CustomerAddress] NVARCHAR(50),
	[CustomerGender] BIT DEFAULT 0,
	[CustomerBirthday] DATETIME,
	[CustomerPhone] VARCHAR(15),
)
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
    [IsExhibited] BIT DEFAULT 0, -- 1 if exhibited, else 0
    [Price] INT , -- if this painting has exhibited, it's must be set the price
    [IsPaid]  BIT DEFAULT 0 ,-- 1 if paid , else 0
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
--User all pass 123456
delete from Users

INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('admin',
            'e10adc3949ba59abbe56e057f20f883e',
            'admin@gmail.com',
            'Admin',
            'ACE-HANOI-12-APROTRAIN',
            '1',
            '01/11/1992',
            '012345678',
            '0')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('victoria',
            'e10adc3949ba59abbe56e057f20f883e',
            'victoria@gmail.com',
            'Victoria Ashworth ',
            '788 Catamaugus Ave.',
            '0',
            '01/11/1990',
            '012345678',
            '1')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('helen',
            'e10adc3949ba59abbe56e057f20f883e',
            'helen@gmail.com',
            'Helen Bennett',
            '24-A Avogadro Way - Remulade',
            '1',
            '01/11/1991',
            '012345678',
            '1')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('lesley',
            'e10adc3949ba59abbe56e057f20f883e',
            'lesley@gmail.com',
            'Lesley	Brown',
            '89 Madison St.	Fremont',
            '1',
            '01/6/1989',
            '012345678',
            '1')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('philip',
            'e10adc3949ba59abbe56e057f20f883e',
            'philip@gmail.com',
            'Philip Cramer',
            '679 Carson St.	Portland',
            '1',
            '01/11/2013',
            '012345678',
            '2')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('anabela',
            'e10adc3949ba59abbe56e057f20f883e',
            'anabela@gmail.com',
            'Anabela Domingues',
            '567 Pasadena Ave.Tustin',
            '1',
            '01/11/2013',
            '012345678',
            '2')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('karla',
            'e10adc3949ba59abbe56e057f20f883e',
            'karla@gmail.com',
            'Karla Jablonski',
            'New Moon Books	Boston',
            '0',
            '01/11/1992',
            '012345678',
            '3')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('matti',
            'e10adc3949ba59abbe56e057f20f883e',
            'atti@gmail.com',
            'Matti Karttunen',
            'Binnet & Hardley Washington',
            '1',
            '01/06/1992',
            '012345678',
            '3')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('janine',
            'e10adc3949ba59abbe56e057f20f883e',
            'janine@gmail.com',
            'Janine	Labrune',
            'Scootney Books	New York',
            '0',
            '01/05/1991',
            '012345678',
            '3')
GO
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Email]
           ,[Name]
           ,[Address]
           ,[Gender]
           ,[Birthday]
           ,[Phone]
           ,[Permission])
     VALUES
           ('yoshi',
            'e10adc3949ba59abbe56e057f20f883e',
            'yoshi@gmail.com',
            'Yoshi Latimer',
            'Ramona Publishers Dallas',
            '0',
            '01/04/1992',
            '012345678',
            '3')
GO

--Exhibitions

delete from Exhibitions
INSERT INTO [dbo].[Exhibitions]
           ([ManagerId]
           ,[ExhibitionName]
           ,[StartDate]
           ,[EndDate]
           ,[ExhibitionDescription])
     VALUES
           ('5',
            'No Choice',
            '',
            '',
			'')
GO
--Customer
delete from Customers
INSERT INTO [dbo].[Customers]
           ([CustomerEmail]
           ,[CustomerName]
           ,[CustomerAddress]
           ,[CustomerGender]
           ,[CustomerBirthday]
           ,[CustomerPhone])
     VALUES
           ('',
            'No Choice',
            '',
            '',
            '',
			'')
GO
--Competitions
delete from Competitions
INSERT INTO [dbo].[Competitions]
           ([StaffId]
           ,[Topic]
           ,[StartDate]
           ,[DueDate]
           ,[CompetitionDescription]
           ,[Condition]
           ,[Remark])
     VALUES
           ('2',
            'Painting Drug Prevention',
            '02/7/2013',
            '03/9/2013',
            'Drugs ruin peoples lives just hand out drugs to have a difficult life more beautiful life!',
            'Pass Graphic,Framed',
            '')
GO
INSERT INTO [dbo].[Competitions]
           ([StaffId]
           ,[Topic]
           ,[StartDate]
           ,[DueDate]
           ,[CompetitionDescription]
           ,[Condition]
           ,[Remark])
     VALUES
           ('2',
            'Painting for Peace',
            '08/01/2013',
            '09/21/2013',
            'International Day of Peace, also known as World Peace Day, occurs annually on September 21. This day is devoted to Peace, and especially not at war, such as might be caused by a temporary ceasefire in a war area. International Day of Peace are many national, ethnic, political groups and military compliance. International Day of Peace was first held in 1981 for the first time. So in response to peaceful days we will hold a drawing competition "Painting for Peace" contest ended on September 21!',
            'Pass Graphic,Framed,Garnish',
            '')
GO
INSERT INTO [dbo].[Competitions]
           ([StaffId]
           ,[Topic]
           ,[StartDate]
           ,[DueDate]
           ,[CompetitionDescription]
           ,[Condition]
           ,[Remark])
     VALUES
           ('3',
            'Landscape Painting',
            '01/10/2013',
            '12/11/2013',
            'Landscapes are works of art that feature scenes of nature: mountains, lakes, gardens, rivers, etc. You can be oil paintings, watercolors, gauche, pastels, or prints of any kind.',
            'Pass Graphic,Framed,Garnish',
            '')
GO
INSERT INTO [dbo].[Competitions]
           ([StaffId]
           ,[Topic]
           ,[StartDate]
           ,[DueDate]
           ,[CompetitionDescription]
           ,[Condition]
           ,[Remark])
     VALUES
           ('3',
            'Life painting',
            '01/10/2013',
            '12/11/2013',
            'Life around us, colorful, nature has given us the right to take a life drawing experience everyday life around you, show us how you feel!',
            'Pass Graphic,Framed,Garnish',
            '')
GO
INSERT INTO [dbo].[Competitions]
           ([StaffId]
           ,[Topic]
           ,[StartDate]
           ,[DueDate]
           ,[CompetitionDescription]
           ,[Condition]
           ,[Remark])
     VALUES
           ('4',
            'Painting Nature',
            '06/01/2013',
            '07/01/2013',
            'In addition there are many natural wonders, wild beautiful images that you insert into the picture and make it beautiful!!',
            'Pass Graphic,Framed,Garnish',
            '')
GO
INSERT INTO [dbo].[Competitions]
           ([StaffId]
           ,[Topic]
           ,[StartDate]
           ,[DueDate]
           ,[CompetitionDescription]
           ,[Condition]
           ,[Remark])
     VALUES
           ('2',
            'Watercolor Painting',
            '01/10/2013',
            '02/11/2013',
            'With the theme you choose to use watercolor to create beautiful picture and meaning. Note that only use water colors!',
            'Pass Graphic,Framed,Garnish',
            '')
GO
