CREATE PROCEDURE [dbo].[spTasks_GetAll]
	@TaskGroupId int
AS
begin
	select Id, Name, Description, Priority, IsCompleted, StartDate, EndDate, TaskGroupId
	from dbo.Tasks
	where TaskGroupId = @TaskGroupId
end