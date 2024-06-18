using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Project;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanningProjectController(
        IPlanningProjectService projectService,
        IMapper mapper,
        IAuthenticationManager authenticationManager
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PlanningProjectDTO>>> GetProjects()
        {
            var bearer = HttpContext.Request.Headers["Authorization"];
            var userId = authenticationManager.GetUserId(bearer!);

            var projects = await projectService.GetAllAsync(userId);

            return Ok(mapper.Map<List<PlanningProjectDTO>>(projects));
        }

        [HttpPost]
        public async Task<ActionResult<PlanningProjectDTO>> CreateProject([FromBody] CreatePlanningProjectDTO projectDTO)
        {
            var bearer = HttpContext.Request.Headers["Authorization"];
            var userId = authenticationManager.GetUserId(bearer!);
            
            var project = mapper.Map<PlanningProject>(projectDTO);
            project.UserId = userId;

            var createdProject = await projectService.CreateAsync(project);

            return Ok(mapper.Map<PlanningProjectDTO>(createdProject));
        }

        [HttpPut]
        public async Task<ActionResult<PlanningProjectDTO>> UpdateProject([FromBody] UpdatePlanningProjectDTO projectDTO)
        {
            var project = mapper.Map<PlanningProject>(projectDTO);
            var updatedProject = await projectService.UpdateAsync(project);

            return Ok(mapper.Map<PlanningProjectDTO>(updatedProject));
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult> RemoveProject([FromRoute] int projectId)
        {
            await projectService.DeleteAsync(projectId);

            return NoContent();
        }
    }
}
