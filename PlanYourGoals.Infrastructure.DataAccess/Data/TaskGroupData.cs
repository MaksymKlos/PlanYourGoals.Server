using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Data;

public class TaskGroupData(ISqlDataAccess db) : ICommonData<TaskGroup>
{
    public Task<IEnumerable<TaskGroup>> GetAllAsync(int parentId)
    {
        var parameters = new
        {
            ProjectId = parentId
        };

        return db.LoadDataAsync<TaskGroup, dynamic>(StoredProcedures.GetAllTaskGroups, parameters);
    }

    public Task<int> InsertAsync(TaskGroup entity)
    {
        var parameters = new
        {
            entity.Name,
            entity.Description,
            entity.ProjectId
        };

        return db.SaveSingeAsync(StoredProcedures.InsertTaskGroup, parameters);
    }

    public Task UpdateAsync(TaskGroup entity)
    {
        var parameters = new
        {
            entity.Id,
            entity.Name,
            entity.Description
        };

        return db.SaveDataAsync(StoredProcedures.UpdateTaskGroup, parameters);
    }

    public Task DeleteAsync(int id)
    {
        var parameters = new
        {
            Id = id
        };

        return db.SaveDataAsync(StoredProcedures.DeleteTaskGroup, parameters);
    }
}