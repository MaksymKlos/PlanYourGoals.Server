using PlanYourGoals.Server.Web.Api.Middleware;

namespace PlanYourGoals.Server.Web.Api.Startup;

public static class ApplicationManager
{
    public static void ConfigureApplication(ConfigurationManager configuration, WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<GeneralExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseCors("AllowOrigin");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}