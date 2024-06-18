namespace PlanYourGoals.Server.Web.Api.Models.DTOs.User;

public class UserDTO
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public int CompletedTasks { get; set; }
}