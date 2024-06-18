using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;

namespace PlanYourGoals.Infrastructure.DataAccess.DbAccess;

public class SqlDataAccess(IConfiguration config) : ISqlDataAccess
{
    public async Task<IEnumerable<TEntity>> LoadDataAsync<TEntity, TParams>(string storedProcedure, TParams parameters,
        string connectionId = DbConnection.DefaultConnectionKey)
    {
        using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectionId));

        return await connection.QueryAsync<TEntity>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveDataAsync<TParams>(string storedProcedure, TParams parameters,
        string connectionId = DbConnection.DefaultConnectionKey)
    {
        using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SaveSingeAsync<TParams>(string storedProcedure, TParams parameters,
        string connectionId = DbConnection.DefaultConnectionKey)
    {
        using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectionId));

        return await connection.QuerySingleAsync<int>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }
}