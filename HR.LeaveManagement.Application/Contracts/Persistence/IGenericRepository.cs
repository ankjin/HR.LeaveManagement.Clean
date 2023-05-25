using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        ValueTask<IReadOnlyList<T>> GetAsync();
        ValueTask<T> GetByIdAsync(int id);
        ValueTask CreateAsync(T entity);
        ValueTask UpdateAsync(T entity);
        ValueTask DeleteAsync(T entity);
    }
}