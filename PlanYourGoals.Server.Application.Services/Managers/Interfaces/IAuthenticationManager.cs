namespace PlanYourGoals.Server.Application.Services.Managers.Interfaces;

public interface IAuthenticationManager
{
    int GetUserId(string bearer);
    string GetUserEmail(string bearer);
}