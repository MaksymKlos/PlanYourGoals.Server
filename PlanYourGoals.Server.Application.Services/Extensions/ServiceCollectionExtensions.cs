using Microsoft.Extensions.DependencyInjection;
using PlanYourGoals.Server.Application.Services.Managers;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Application.Services.Services;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;

namespace PlanYourGoals.Server.Application.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IHashService, HashService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IPlanningProjectService, PlanningProjectService>();
        services.AddSingleton<ITaskGroupService, TaskGroupService>();
        services.AddSingleton<ITaskService, TaskService>();
        services.AddSingleton<IAchievementService, AchievementService>();

        services.AddSingleton<IIdentityManager, IdentityManager>();
        services.AddSingleton<IAuthenticationManager, AuthenticationManager>();

        services.AddSingleton<IEmailSenderService, EmailSenderService>();
        services.AddSingleton<IOpenAIService, OpenAIService>();
    }
}