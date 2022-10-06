using Contracts.Repositories;
using Entities.Models;
using Infrastructure;

namespace Repositories;

public class LoggerRepository : RepositoryBase<Log>, ILoggerRepository
{
    public LoggerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Log> Log(Log log) => await CreateAsync(log);
}