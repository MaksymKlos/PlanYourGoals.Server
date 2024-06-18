using PlanYourGoals.Infrastructure.DataAccess.Constants;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces;
using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Data;

public class IdentityUserData(ISqlDataAccess db) : IUserData<IdentityUser>
{
    public Task<int> InsertAsync(IdentityUser user)
    {
        var parameters = new
        {
            user.Email,
            user.HashedPassword
        };

        return db.SaveSingeAsync(StoredProcedures.InsertIdentityUser, parameters);
    }

    public Task UpdateAsync(IdentityUser user)
    {
        var parameters = new
        {
            user.Id,
            user.Email
        };

        return db.SaveDataAsync(StoredProcedures.InsertIdentityUser, parameters);
    }

    public async Task<IdentityUser?> GetByEmailAsync(string email)
    {
        var parameters = new
        {
            Email = email
        };

        var data = await db.LoadDataAsync<IdentityUser, dynamic>(
            StoredProcedures.GetIdentityUser, parameters);

        return data.FirstOrDefault();
    }
}