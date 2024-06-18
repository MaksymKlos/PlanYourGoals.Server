CREATE PROCEDURE [dbo].[spIdentityUsers_GetByEmail]
	@Email nvarchar(100)
AS
begin
	select Id, Email, HashedPassword
	from dbo.IdentityUsers
	where Email = @Email
end