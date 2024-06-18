CREATE PROCEDURE [dbo].[spTaskGroups_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(100)
AS
begin
	update dbo.TaskGroups
	set Name = @Name, Description = @Description
	where Id = @Id
end