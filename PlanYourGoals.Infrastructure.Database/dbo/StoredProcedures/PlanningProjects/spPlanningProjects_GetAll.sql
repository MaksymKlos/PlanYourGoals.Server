CREATE PROCEDURE [dbo].[spPlanningProjects_GetAll]
	@UserId int
AS
begin
	select Id, Name, UserId
	from dbo.PlanningProjects
	where UserId = @UserId
end