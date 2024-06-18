namespace PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;

public interface ICommonData<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(int parentId);
    Task<int> InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}