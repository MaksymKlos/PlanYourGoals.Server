using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface IAchievementService
{
    Task<List<Achievement>> GetAllAsync();
    Task<Achievement> CreateAsync(Achievement achievement);
    Task<Achievement> UpdateAsync(Achievement achievement);
    Task DeleteAsync(int id);
}