CREATE PROCEDURE [dbo].[spAchievements_Update]
	@Id int,
	@Name nvarchar(50),
	@Scores int,
	@ImageUrl nvarchar(MAX)
AS
begin
	update dbo.Achievements
	set Name = @Name, Scores = @Scores, ImageUrl = @ImageUrl
	where Id = @Id
end