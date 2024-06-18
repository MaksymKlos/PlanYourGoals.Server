using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Application.Services.Models;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Managers;

public class IdentityManager(IHashService hashService, IUserData<IdentityUser> identityData) : IIdentityManager
{
    public async Task RegisterIdentityAsync(NewIdentityUser user)
    {
        var passwordHash = await hashService.GetHashAsync(user.Password);

        var identity = new IdentityUser
        {
            Email = user.Email,
            HashedPassword = passwordHash
        };

        await identityData.InsertAsync(identity);
    }

    public async Task<IdentityUser?> FindByEmailAsync(string email)
    {
        return await identityData.GetByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(IdentityUser user, string password)
    {
        var sentPasswordHash = await hashService.GetHashAsync(password);
        
        return user.HashedPassword == sentPasswordHash;
    }
}