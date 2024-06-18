using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Task;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController(ITaskService taskService, IMapper mapper, IAuthenticationManager authenticationManager) : ControllerBase
    {
        [HttpGet("{groupId}")]
        public async Task<ActionResult<List<TaskModelDTO>>> GetTasks([FromRoute] int groupId)
        {
            var tasks = await taskService.GetAllAsync(groupId);

            return Ok(mapper.Map<List<TaskModelDTO>>(tasks));
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModelDTO>>> GetUserTasks()
        {
            var bearer = HttpContext.Request.Headers["Authorization"];
            var userId = authenticationManager.GetUserId(bearer!);
            var tasks = await taskService.GetUserTasksAsync(userId);

            return Ok(mapper.Map<List<TaskModelDTO>>(tasks));
        }

        [HttpPost]
        public async Task<ActionResult<TaskModelDTO>> CreateTask([FromBody] CreateTaskModelDTO taskDTO)
        {
            var task = mapper.Map<TaskModel>(taskDTO);
            var createdTask = await taskService.CreateAsync(task);

            return Ok(mapper.Map<TaskModelDTO>(createdTask));
        }

        [HttpPut]
        public async Task<ActionResult<TaskModelDTO>> UpdateTask([FromBody] UpdateTaskModelDTO taskDTO)
        {
            var task = mapper.Map<TaskModel>(taskDTO);

            var updatedTask = await taskService.UpdateAsync(task);

            return Ok(mapper.Map<TaskModelDTO>(updatedTask));
        }

        [HttpPatch("{taskId}")]
        public async Task<ActionResult> UpdateTaskState(
            [FromRoute] int taskId,
            [FromBody] UpdateTaskStateDTO taskState)
        {
            await taskService.UpdateTaskStateAsync(taskId, taskState.IsCompleted);

            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public async Task<ActionResult> RemoveTask([FromRoute] int taskId)
        {
            await taskService.DeleteAsync(taskId);

            return NoContent();
        }
    }
}
