CREATE PROCEDURE [dbo].[spPlanningProjects_Insert]
	@Name nvarchar(50),
	@UserId int
AS
begin
	insert into dbo.PlanningProjects(Name, UserId)
	output inserted.[Id]
	values (@Name, @UserId)
end