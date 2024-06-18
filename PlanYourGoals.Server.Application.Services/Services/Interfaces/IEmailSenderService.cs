namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface IEmailSenderService
{
    Task SendAsync(string receiverEmail, string subject, string message);
}