using Entities.Models;

namespace Contracts.Repositories;

public interface ILoggerRepository : IRepositoryBase<Log>
{
   Task<Log> Log(Log log);
}