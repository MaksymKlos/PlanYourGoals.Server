namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface IOpenAIService
{
    Task<string> CreateConversationAsync(string botModelName, string userInput);
}