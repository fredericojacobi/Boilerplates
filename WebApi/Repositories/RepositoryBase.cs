using System.Linq.Expressions;
using Contracts.Repositories;
using Generics.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
{
    private AppDbContext _context { get; }

    protected RepositoryBase(AppDbContext context) => _context = context;

    public async Task<IEnumerable<T>> ReadAllAsync(params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().AsQueryable();
        includeExpressions
            .ToList()
            .ForEach(x => query = query.Include(x));
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Pagination<T>> ReadAllPaginatedAsync(int page, int limit)
    {
        var totalRecords = await _context.Set<T>().CountAsync();
        var result = await _context.Set<T>()
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
        return new Pagination<T>(result, totalRecords, page, limit);
    }

    public async Task<IEnumerable<T>> ReadByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeExpressions)
    {
        var query = _context.Set<T>().Where(expression);
        includeExpressions
            .ToList()
            .ForEach(x => query = query.Include(x));
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.Now;
        await _context.Set<T>().AddAsync(entity);
        await SaveAsync();
        await ReloadAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(Guid id, T entity)
    {
        entity.ModifiedAt = DateTime.Now;
        var currentEntity = await _context.Set<T>().FindAsync(id);
        _context.Entry(currentEntity).CurrentValues.SetValues(entity);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

    private async Task ReloadAsync(T entity) => await _context.Entry(entity).ReloadAsync();
}