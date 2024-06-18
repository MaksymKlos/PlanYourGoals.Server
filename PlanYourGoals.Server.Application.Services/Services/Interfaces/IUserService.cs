using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services.Interfaces;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}