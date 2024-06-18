CREATE PROCEDURE [dbo].[spAchievements_GetAll]
AS
begin
	select Id, Name, Scores, ImageUrl
	from dbo.Achievements
end