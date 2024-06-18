using Microsoft.Extensions.DependencyInjection;
using PlanYourGoals.Infrastructure.DataAccess.Data;
using PlanYourGoals.Infrastructure.DataAccess.DbAccess;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

        services.AddSingleton<ICommonData<PlanningProject>, PlanningProjectData>();
        services.AddSingleton<ICommonData<TaskGroup>, TaskGroupData>();
        services.AddSingleton<ICommonData<Achievement>, AchievementData>();

        services.AddSingleton<IExtendedData<TaskModel>, TaskData>();

        services.AddSingleton<IUserData<IdentityUser>, IdentityUserData>();
        services.AddSingleton<IUserData<User>, UserData>();
    }
}