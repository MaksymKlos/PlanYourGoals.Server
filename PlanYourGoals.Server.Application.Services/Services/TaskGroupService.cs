using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services;

public class TaskGroupService(ICommonData<TaskGroup> taskGroupData) : ITaskGroupService
{
    public async Task<List<TaskGroup>> GetAllAsync(int projectId)
    {
        var projects = await taskGroupData.GetAllAsync(projectId);

        return projects.ToList();
    }

    public async Task<TaskGroup> CreateAsync(TaskGroup taskGroup)
    {
        var id = await taskGroupData.InsertAsync(taskGroup);
        taskGroup.Id = id;

        return taskGroup;
    }

    public async Task<TaskGroup> UpdateAsync(TaskGroup taskGroup)
    {
        await taskGroupData.UpdateAsync(taskGroup);

        return taskGroup;
    }

    public async Task DeleteAsync(int id)
    {
        await taskGroupData.DeleteAsync(id);
    }
}