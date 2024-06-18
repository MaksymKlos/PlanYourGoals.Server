CREATE PROCEDURE [dbo].[spUsers_Insert]
	@Name nvarchar(50),
	@Email nvarchar(100)
AS
begin
	insert into dbo.Users(Name, Email, CompletedTasks)
	output inserted.[Id]
	values (@Name, @Email, 0)
end