using System.Linq.Expressions;

namespace ConstructionManagementAssistant_Core.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(string[] includes = null);

    Task<T> GetByIdAsync(int Id, string[] includes = null);
    Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null);
    Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate, string[] includes = null);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(int Id);

}
