namespace PlanYourGoals.Server.Web.Api.Models.DTOs.User;

public class UserRegistrationRequestDTO
{
    public required string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}