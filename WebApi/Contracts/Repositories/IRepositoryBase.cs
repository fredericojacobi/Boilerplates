using System.Linq.Expressions;

namespace Contracts.Repositories;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> ReadAllAsync(params Expression<Func<T, Object>>[] includeExpressions);
    Task<IEnumerable<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, Object>>[] includeExpressions);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> SaveAsync();
}