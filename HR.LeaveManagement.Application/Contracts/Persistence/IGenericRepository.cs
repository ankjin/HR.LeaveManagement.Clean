namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        ValueTask<List<T>> GetAsync();
        ValueTask<T> GetByIdAsync(int id);
        ValueTask<T> CreateAsync(T entity);
        ValueTask<T> UpdateAsync(T entity);
        ValueTask<T> DeleteAsync(T entity);
    }
}