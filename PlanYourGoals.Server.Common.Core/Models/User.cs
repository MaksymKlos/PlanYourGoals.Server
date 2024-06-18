namespace PlanYourGoals.Server.Common.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int CompletedTasks { get; set; }
}