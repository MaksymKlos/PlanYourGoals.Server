using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Data;

public class UserData(ISqlDataAccess db) : IUserData<User>
{
    public Task<int> InsertAsync(User user)
    {
        var parameters = new
        {
            user.Name,
            user.Email
        };

        return db.SaveSingeAsync(StoredProcedures.InsertUser, parameters);
    }

    public Task UpdateAsync(User user)
    {
        var parameters = new
        {
            user.Id,
            user.Name,
            user.Email
        };

        return db.SaveDataAsync(StoredProcedures.UpdateUser, parameters);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var parameters = new
        {
            Email = email
        };

        var data = await db.LoadDataAsync<User, dynamic>(
            StoredProcedures.GetUserByEmail, parameters);

        return data.FirstOrDefault();
    }
}