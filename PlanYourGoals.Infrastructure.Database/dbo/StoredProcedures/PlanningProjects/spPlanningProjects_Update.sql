CREATE PROCEDURE [dbo].[spPlanningProjects_Update]
	@Id int,
	@Name nvarchar(50)
AS
begin
	update dbo.PlanningProjects
	set Name = @Name
	where Id = @Id
end