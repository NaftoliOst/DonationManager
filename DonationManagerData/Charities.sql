CREATE TABLE [dbo].[Charities]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [OfficialName] NVARCHAR(50) NULL, 
    [PreferredMethod] NVARCHAR(50) NULL, 
    [Details] NVARCHAR(MAX) NULL, 
    [Type] NVARCHAR(50) NULL, 
    [Notes] NVARCHAR(MAX) NULL
)
