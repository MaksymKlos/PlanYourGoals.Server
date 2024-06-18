namespace PlanYourGoals.Server.Common.Core.Models;

public class IdentityUser
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
}