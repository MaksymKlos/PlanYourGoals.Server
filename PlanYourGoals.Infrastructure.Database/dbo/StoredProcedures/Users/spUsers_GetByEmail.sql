CREATE PROCEDURE [dbo].[spUsers_GetByEmail]
	@Email nvarchar(100)
AS
begin
	select Id, Name, Email, CompletedTasks
	from dbo.Users
	where Email = @Email
end