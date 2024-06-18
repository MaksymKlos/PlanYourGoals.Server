using PlanYourGoals.Server.Application.Services.Models;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Managers.Interfaces;

public interface IIdentityManager
{
    Task RegisterIdentityAsync(NewIdentityUser user);
    Task<IdentityUser?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(IdentityUser user, string password);
}