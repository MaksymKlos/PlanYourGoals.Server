using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface ITaskGroupService
{
    Task<List<TaskGroup>> GetAllAsync(int projectId);
    Task<TaskGroup> CreateAsync(TaskGroup taskGroup);
    Task<TaskGroup> UpdateAsync(TaskGroup taskGroup);
    Task DeleteAsync(int id);
}