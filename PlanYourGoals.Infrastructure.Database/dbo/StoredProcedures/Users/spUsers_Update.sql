CREATE PROCEDURE [dbo].[spUsers_Update]
	@Id int,
	@Name nvarchar(50),
	@Email nvarchar(100)
AS
begin
	update dbo.Users
	set Name = @Name, Email = @Email
	where Id = @Id
end