using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services;

public class AchievementService(ICommonData<Achievement> achievementData) : IAchievementService
{
    public async Task<List<Achievement>> GetAllAsync()
    {
        var tasks = await achievementData.GetAllAsync(0);

        return tasks.ToList();
    }

    public async Task<Achievement> CreateAsync(Achievement achievement)
    {
        var id = await achievementData.InsertAsync(achievement);
        achievement.Id = id;

        return achievement;
    }

    public async Task<Achievement> UpdateAsync(Achievement achievement)
    {
        await achievementData.UpdateAsync(achievement);

        return achievement;
    }

    public async Task DeleteAsync(int id)
    {
        await achievementData.DeleteAsync(id);
    }
}