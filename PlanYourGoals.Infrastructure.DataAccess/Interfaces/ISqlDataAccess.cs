using PlanYourGoals.Infrastructure.DataAccess.Constants;

namespace PlanYourGoals.Infrastructure.DataAccess.Interfaces;

public interface ISqlDataAccess
{
    Task<IEnumerable<TEntity>> LoadDataAsync<TEntity, TParams>(string storedProcedure, TParams parameters,
        string connectionId = DbConnection.DefaultConnectionKey);

    Task SaveDataAsync<TParams>(string storedProcedure, TParams parameters,
        string connectionId = DbConnection.DefaultConnectionKey);

    Task<int> SaveSingeAsync<TParams>(string storedProcedure, TParams parameters,
        string connectionId = DbConnection.DefaultConnectionKey);
}