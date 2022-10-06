namespace Contracts.Repositories;

public interface IRepositoryWrapper
{
    IUserApplicationRepository UserApplication { get; }
    ILoggerRepository Logger { get; }
}