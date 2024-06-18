CREATE TABLE [dbo].[TaskGroups]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    [ProjectId] INT NOT NULL FOREIGN KEY REFERENCES PlanningProjects(Id)
)
