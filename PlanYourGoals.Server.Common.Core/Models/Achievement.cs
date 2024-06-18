namespace PlanYourGoals.Server.Common.Core.Models;

public class Achievement
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Scores { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}