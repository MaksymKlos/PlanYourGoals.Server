using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services;

public class UserService(IUserData<User> usersData) : IUserService
{
    public async Task<User> CreateAsync(User user)
    {
        var id = await usersData.InsertAsync(user);
        user.Id = id;

        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await usersData.UpdateAsync(user);

        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await usersData.GetByEmailAsync(email);
    }
}