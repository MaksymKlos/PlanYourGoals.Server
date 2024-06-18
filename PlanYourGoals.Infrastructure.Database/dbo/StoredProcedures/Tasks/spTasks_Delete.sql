CREATE PROCEDURE [dbo].[spTasks_Delete]
	@Id int
AS
begin
	delete
	from dbo.Tasks
	where Id = @Id
end