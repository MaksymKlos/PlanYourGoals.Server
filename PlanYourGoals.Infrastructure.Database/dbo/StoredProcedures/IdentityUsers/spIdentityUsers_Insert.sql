CREATE PROCEDURE [dbo].[spIdentityUsers_Insert]
	@Email nvarchar(100),
	@HashedPassword nvarchar(MAX)
AS
begin
	insert into dbo.IdentityUsers(Email, HashedPassword)
	output inserted.[Id]
	values (@Email, @HashedPassword)
end