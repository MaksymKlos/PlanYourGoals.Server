namespace PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;

public interface IUserData<T>
{
    Task<int> InsertAsync(T user);
    Task UpdateAsync(T user);
    Task<T?> GetByEmailAsync(string email);
}