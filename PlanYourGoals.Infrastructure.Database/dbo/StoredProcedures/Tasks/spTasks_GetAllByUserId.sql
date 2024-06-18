CREATE PROCEDURE [dbo].[spTasks_GetAllByUserId]
	@UserId int
AS
begin
	select Id, Name, Description, Priority, IsCompleted, StartDate, EndDate, TaskGroupId
	from dbo.Tasks
	where TaskGroupId IN 
	-- Select all tasks related to user--
	(select Id from TaskGroups where ProjectId IN (select Id from PlanningProjects where UserId = @UserId));
end