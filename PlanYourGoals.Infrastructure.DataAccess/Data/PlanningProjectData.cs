using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Data;

public class PlanningProjectData(ISqlDataAccess db) : ICommonData<PlanningProject>
{
    public Task<IEnumerable<PlanningProject>> GetAllAsync(int parentId)
    {
        var parameters = new
        {
            UserId = parentId
        };

        return db.LoadDataAsync<PlanningProject, dynamic>(
            StoredProcedures.GetAllProjects, parameters);
    }
    
    public Task<int> InsertAsync(PlanningProject entity)
    {
        var parameters = new
        {
            entity.Name,
            entity.UserId
        };

        return db.SaveSingeAsync(StoredProcedures.InsertProject, parameters);
    }

    public Task UpdateAsync(PlanningProject entity)
    {
        var parameters = new
        {
            entity.Id,
            entity.Name
        };

        return db.SaveDataAsync(StoredProcedures.UpdateProject, parameters);
    }

    public Task DeleteAsync(int id)
    {
        var parameters = new
        {
            Id = id
        };

        return db.SaveDataAsync(StoredProcedures.DeleteProject, parameters);
    }
}