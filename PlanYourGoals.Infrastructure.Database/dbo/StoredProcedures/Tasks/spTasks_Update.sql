CREATE PROCEDURE [dbo].[spTasks_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(100),
	@Priority tinyint,
	@StartDate datetime2(7),
	@EndDate datetime2(7)
AS
begin
	update dbo.Tasks
	set Name = @Name, Description = @Description, Priority = @Priority, StartDate = @StartDate, EndDate = @EndDate
	where Id = @Id
end