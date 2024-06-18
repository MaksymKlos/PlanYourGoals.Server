using PlanYourGoals.Server.Web.Api.Startup;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

ServiceManager.ConfigureServices(configuration, services);

var app = builder.Build();

ApplicationManager.ConfigureApplication(configuration, app);

app.Run();