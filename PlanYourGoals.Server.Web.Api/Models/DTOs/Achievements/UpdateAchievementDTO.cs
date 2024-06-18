namespace PlanYourGoals.Server.Web.Api.Models.DTOs.Achievements;

public class CreateAchievementDTO
{
    public required string Name { get; set; } = string.Empty;
    public required int Scores { get; set; }
    public required string ImageUrl { get; set; } = string.Empty;
}