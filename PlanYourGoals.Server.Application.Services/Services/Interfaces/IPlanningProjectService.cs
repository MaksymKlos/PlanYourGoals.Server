using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface IPlanningProjectService
{
    Task<List<PlanningProject>> GetAllAsync(int userId);
    Task<PlanningProject> CreateAsync(PlanningProject project);
    Task<PlanningProject> UpdateAsync(PlanningProject project);
    Task DeleteAsync(int id);
}