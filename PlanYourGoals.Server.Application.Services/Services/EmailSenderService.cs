using System.Net;
using System.Net.Mail;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;

namespace PlanYourGoals.Server.Application.Services.Services;

public class EmailSenderService : IEmailSenderService
{
    public Task SendAsync(string receiverEmail, string subject, string message)
    {
        var senderEmail = "klosmax62@gmail.com";
        var senderPassword = "hhqq zakd fcgz cvgb";

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            DeliveryMethod = SmtpDeliveryMethod.Network,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(senderEmail, senderPassword)
        };

        var mail = new MailMessage(senderEmail, receiverEmail, subject, message);

        return client.SendMailAsync(mail);
    }
}