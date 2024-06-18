using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Achievements;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController(IMapper mapper, IAchievementService achievementService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AchievementDTO>>> GetAllAchievements()
        {
            var achievements = await achievementService.GetAllAsync();

            return Ok(mapper.Map<List<AchievementDTO>>(achievements));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAchievement(CreateAchievementDTO achievementDTO)
        {
            var achievement = mapper.Map<Achievement>(achievementDTO);
            var createdAchievement = await achievementService.CreateAsync(achievement);

            return Ok(mapper.Map<AchievementDTO>(createdAchievement));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAchievement(AchievementDTO achievementDTO)
        {
            var achievement = mapper.Map<Achievement>(achievementDTO);
            var updatedAchievement = await achievementService.UpdateAsync(achievement);

            return Ok(mapper.Map<AchievementDTO>(updatedAchievement));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAchievement(int id)
        {
            await achievementService.DeleteAsync(id);

            return NoContent();
        }
    }
}