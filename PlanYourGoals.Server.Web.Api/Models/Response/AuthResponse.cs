namespace PlanYourGoals.Server.Web.Api.Models.Response;

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public bool Result { get; set; }
    public string Error { get; set; } = string.Empty;
}