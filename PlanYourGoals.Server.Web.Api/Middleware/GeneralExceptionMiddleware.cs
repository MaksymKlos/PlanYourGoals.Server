using PlanYourGoals.Server.Common.Core.Exceptions;
using PlanYourGoals.Server.Web.Api.Constants;

namespace PlanYourGoals.Server.Web.Api.Middleware;

public class GeneralExceptionMiddleware(RequestDelegate requestDelegate, IWebHostEnvironment environment, ILoggerFactory logger)
{
    private readonly ILogger logger = logger.CreateLogger<GeneralExceptionMiddleware>();

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await requestDelegate(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var detailsResponse = string.Empty;

        switch (exception)
        {
            case BadRequestException:
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                detailsResponse = exception.Message;
                break;
            case NotImplementedException:
                httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                break;
            case AuthenticationException:
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                detailsResponse = exception.Message;
                break;
            case NotFoundException:
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                detailsResponse = exception.Message;
                break;
            case ForbiddenException:
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                detailsResponse = exception.Message;
                break;
            default:
            {
                var errorMessage = environment.IsDevelopment() ? exception.ToString() : ErrorMessages.InternalServerError;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                detailsResponse = errorMessage;
                break;
            }
        }

        logger.LogError(exception.ToString());

        await httpContext.Response.WriteAsync(detailsResponse);
    }
}