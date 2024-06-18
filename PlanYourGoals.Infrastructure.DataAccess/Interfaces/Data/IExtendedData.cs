using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;

public interface IExtendedData<T> : ICommonData<T> where T : class
{
    Task UpdateFieldAsync(int id, string fieldName, object field);
    Task<IEnumerable<TaskModel>> GetAllByUserIdAsync(int userId);
}