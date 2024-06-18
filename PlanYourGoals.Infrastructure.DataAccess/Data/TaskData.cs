using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Data;

public class TaskData(ISqlDataAccess db) : IExtendedData<TaskModel>
{
    public Task<IEnumerable<TaskModel>> GetAllAsync(int parentId)
    {
        var parameters = new
        {
            TaskGroupId = parentId
        };

        return db.LoadDataAsync<TaskModel, dynamic>(
            StoredProcedures.GetAllTasks, parameters);
    }

    public Task<IEnumerable<TaskModel>> GetAllByUserIdAsync(int userId)
    {
        var parameters = new
        {
            UserId = userId
        };

        return db.LoadDataAsync<TaskModel, dynamic>(
            StoredProcedures.GetAllTasksByUserId, parameters);
    }

    public Task<int> InsertAsync(TaskModel entity)
    {
        var parameters = new
        {
            entity.Name,
            entity.Description,
            entity.Priority,
            entity.StartDate,
            entity.EndDate,
            entity.TaskGroupId
        };

        return db.SaveSingeAsync(StoredProcedures.InsertTask, parameters);
    }

    public Task UpdateAsync(TaskModel entity)
    {
        var parameters = new
        {
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Priority,
            entity.StartDate,
            entity.EndDate
        };

        return db.SaveDataAsync(StoredProcedures.UpdateTask, parameters);
    }

    public Task DeleteAsync(int id)
    {
        var parameters = new
        {
            Id = id
        };

        return db.SaveDataAsync(StoredProcedures.DeleteTask, parameters);
    }

    public Task UpdateFieldAsync(int id, string fieldName, object field)
    {
        var parameters = new Dictionary<string, object>()
        {
            {"Id", id.ToString()},
            {fieldName, field}
        };

        return db.SaveDataAsync(StoredProcedures.UpdateTaskState, parameters);
    }
}