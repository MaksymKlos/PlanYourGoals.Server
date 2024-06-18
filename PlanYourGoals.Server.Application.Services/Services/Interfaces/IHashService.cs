namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface IHashService
{
    Task<string> GetHashAsync(string plainText);
}