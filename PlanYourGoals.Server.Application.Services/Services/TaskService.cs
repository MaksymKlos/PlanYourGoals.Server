using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services;

public class TaskService(IExtendedData<TaskModel> taskData) : ITaskService
{
    public async Task<List<TaskModel>> GetAllAsync(int taskGroupId)
    {
        var tasks = await taskData.GetAllAsync(taskGroupId);

        return tasks.ToList();
    }

    public async Task<List<TaskModel>> GetUserTasksAsync(int userId)
    {
        var task = await taskData.GetAllByUserIdAsync(userId);

        return task.ToList();
    }

    public async Task<TaskModel> CreateAsync(TaskModel task)
    {
        if(task.StartDate == null)
        {
            task.StartDate = DateTime.UtcNow;
        }

        var id = await taskData.InsertAsync(task);

        task.Id = id;

        return task;
    }

    public async Task<TaskModel> UpdateAsync(TaskModel task)
    {
        if(task.StartDate == null)
        {
            task.StartDate = DateTime.UtcNow;
        }

        await taskData.UpdateAsync(task);

        return task;
    }

    public async Task DeleteAsync(int id)
    {
        await taskData.DeleteAsync(id);
    }

    public async Task UpdateTaskStateAsync(int id, bool isCompleted)
    {
        await taskData.UpdateFieldAsync(id, "IsCompleted", isCompleted);
    }
}