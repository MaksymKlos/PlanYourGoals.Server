using PlanYourGoals.Infrastructure.DataAccess.Extensions;
using PlanYourGoals.Server.Application.Services.Extensions;
using PlanYourGoals.Server.Web.Api.Extensions;
using PlanYourGoals.Server.Web.Api.Profiles;

namespace PlanYourGoals.Server.Web.Api.Startup;

public class ServiceManager
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddInfrastructureServices();
        services.AddApplicationServices();

        services.ConfigureApiOptions(configuration);
        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddConfiguredSwaggerGen();

        services.AddJwtAuthentication(configuration);
        services.AddGenericCors();
    }
}