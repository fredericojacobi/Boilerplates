using System.Linq.Expressions;
using Generics.Models;

namespace Contracts.Repositories;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> ReadAllAsync(params Expression<Func<T, object>>[] includeExpressions);
    Task<Pagination<T>> ReadAllPaginatedAsync(int page, int limit);
    Task<IEnumerable<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeExpressions);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> SaveAsync();
}