CREATE PROCEDURE [dbo].[spAchievements_Insert]
	@Name nvarchar(50),
	@Scores int,
	@ImageUrl nvarchar(MAX)
AS
begin
	insert into dbo.Achievements(Name, Scores, ImageUrl)
	output inserted.[Id]
	values (@Name, @Scores, @ImageUrl)
end