using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Data;

public class AchievementData(ISqlDataAccess db) : ICommonData<Achievement>
{
    public Task<IEnumerable<Achievement>> GetAllAsync(int parentId)
    {
        return db.LoadDataAsync<Achievement, dynamic>(StoredProcedures.GetAllAchievements, new { });
    }

    public Task<int> InsertAsync(Achievement entity)
    {
        var parameters = new
        {
            entity.Name,
            entity.Scores,
            entity.ImageUrl
        };

        return db.SaveSingeAsync(StoredProcedures.InsertAchievement, parameters);
    }

    public Task UpdateAsync(Achievement entity)
    {
        var parameters = new
        {
            entity.Id,
            entity.Name,
            entity.Scores,
            entity.ImageUrl
        };

        return db.SaveDataAsync(StoredProcedures.UpdateAchievement, parameters);
    }

    public Task DeleteAsync(int id)
    {
        var parameters = new
        {
            Id = id
        };

        return db.SaveDataAsync(StoredProcedures.DeleteAchievement, parameters);
    }
}