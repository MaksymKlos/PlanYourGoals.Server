CREATE TABLE [dbo].[Achievements]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Scores] INT NOT NULL, 
    [ImageUrl] NVARCHAR(MAX) NOT NULL
)