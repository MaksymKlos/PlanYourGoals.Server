CREATE PROCEDURE [dbo].[spTaskGroups_Insert]
	@Name nvarchar(50),
	@Description nvarchar(100),
	@ProjectId int
AS
begin
	insert into dbo.TaskGroups(Name, Description, ProjectId)
	output inserted.[Id]
	values (@Name, @Description, @ProjectId)
end