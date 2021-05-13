CREATE TABLE [dbo].[Donations]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Charity] INT NOT NULL, 
    [Person] INT NOT NULL, 
    [Cause] INT NULL, 
    [Date] DATE NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Note] NVARCHAR(MAX) NULL, 
    [Method] NVARCHAR(50) NULL, 
    [UserID] NCHAR(10) NULL
)
