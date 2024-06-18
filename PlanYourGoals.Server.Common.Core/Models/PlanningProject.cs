namespace PlanYourGoals.Server.Common.Core.Models;

public class PlanningProject
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}