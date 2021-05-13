CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)
