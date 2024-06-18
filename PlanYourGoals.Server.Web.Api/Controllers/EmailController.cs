using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Email;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController(IEmailSenderService emailSender, IAuthenticationManager authenticationManager) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> SendEmail([FromBody] ContactMessage contactMessage)
        {
            var bearer = HttpContext.Request.Headers["Authorization"];
            var userEmail = authenticationManager.GetUserEmail(bearer!);

            var email = "klosmax62@gmail.com";
            var subject = "PlanYourGoals Help";
            contactMessage.Message += $"\nUser Email: {userEmail}";

            await emailSender.SendAsync(email, subject, contactMessage.Message);

            return NoContent();
        }
    }
}
