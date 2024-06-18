using OpenAI_API;
using PlanYourGoals.Server.Application.Services.Constants;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;

namespace PlanYourGoals.Server.Application.Services.Services;

public class OpenAIService: IOpenAIService
{
    private readonly OpenAIAPI openAi = new(new APIAuthentication(
        "sk-proj-lQWN9yu5OEklFBRIKnNwT3BlbkFJJu8We2zS5iXhd1dSpQTP"));

    public async Task<string> CreateConversationAsync(string botModelName, string userInput)
    {
        var conversation = openAi.Chat.CreateConversation();

        //conversation.Model = "gpt-3.5-turbo";
        conversation.Model = botModelName;

        conversation.AppendSystemMessage(Bot.PlanningSystemMessage);
        conversation.AppendUserInput(userInput);

        var response = await conversation.GetResponseFromChatbotAsync();

        return response;
    }
}