using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Project;
using PlanYourGoals.Server.Web.Api.Models.DTOs.TaskGroup;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskGroupController(ITaskGroupService taskGroupService, IMapper mapper) : ControllerBase
    {
        [HttpGet("{projectId}")]
        public async Task<ActionResult<List<PlanningProjectDTO>>> GetTaskGroups([FromRoute] int projectId)
        {
            var taskGroups = await taskGroupService.GetAllAsync(projectId);
   
            return Ok(mapper.Map<List<TaskGroupDTO>>(taskGroups));
        }

        [HttpPost]
        public async Task<ActionResult<TaskGroupDTO>> CreateTaskGroup([FromBody] CreateTaskGroupDTO groupDTO)
        {
            var taskGroup = mapper.Map<TaskGroup>(groupDTO);
            var createdGroup = await taskGroupService.CreateAsync(taskGroup);

            return Ok(mapper.Map<TaskGroupDTO>(createdGroup));
        }

        [HttpPut]
        public async Task<ActionResult<TaskGroupDTO>> UpdateTaskGroup([FromBody] UpdateTaskGroupDTO groupDTO)
        {
            var taskGroup = mapper.Map<TaskGroup>(groupDTO);
            
            var updatedGroup = await taskGroupService.UpdateAsync(taskGroup);

            return Ok(mapper.Map<TaskGroupDTO>(updatedGroup));
        }

        [HttpDelete("{groupId}")]
        public async Task<ActionResult> RemoveTaskGroup([FromRoute] int groupId)
        {
            await taskGroupService.DeleteAsync(groupId);

            return NoContent();
        }
    }
}