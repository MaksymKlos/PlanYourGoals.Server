CREATE PROCEDURE [dbo].[spIdentityUsers_Update]
	@Id int,
	@Email nvarchar(100)
AS
begin
	update dbo.Users
	set Email = @Email
	where Id = @Id
end