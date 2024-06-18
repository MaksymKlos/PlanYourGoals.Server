CREATE PROCEDURE [dbo].[spAchievements_Delete]
	@Id int
AS
begin
	delete
	from dbo.Achievements
	where Id = @Id;
end