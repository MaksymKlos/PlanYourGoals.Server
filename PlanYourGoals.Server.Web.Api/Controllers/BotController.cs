using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Bot;
using PlanYourGoals.Server.Web.Api.Models.Response;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController(IOpenAIService openAIService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BotResponse>> GetResponse([FromBody]BotRequstDTO request)
        {
            var response = await openAIService.CreateConversationAsync(request.BotModelName, request.Message);

            return Ok(new BotResponse
            {
                BotMessage = response
            });
        }
    }
}
