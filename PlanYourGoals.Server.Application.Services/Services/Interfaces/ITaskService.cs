using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskModel>> GetAllAsync(int taskGroupId);
    Task<List<TaskModel>> GetUserTasksAsync(int userId);
    Task<TaskModel> CreateAsync(TaskModel task);
    Task<TaskModel> UpdateAsync(TaskModel task);
    Task DeleteAsync(int id);
    Task UpdateTaskStateAsync(int id, bool isCompleted);
}