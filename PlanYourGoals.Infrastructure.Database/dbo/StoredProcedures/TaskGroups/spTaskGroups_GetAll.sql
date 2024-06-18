CREATE PROCEDURE [dbo].[spTaskGroups_GetAll]
	@ProjectId int
AS
begin
	select Id, Name, Description, ProjectId
	from dbo.TaskGroups
	where ProjectId = @ProjectId
end