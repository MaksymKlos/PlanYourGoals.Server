CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Priority] TINYINT NOT NULL, 
    [IsCompleted] BIT NOT NULL DEFAULT 0, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NULL,
    [TaskGroupId] INT NOT NULL FOREIGN KEY REFERENCES TaskGroups(Id)
)
