namespace Contracts.Services;

public interface IServiceWrapper
{
    IUserApplicationService UserApplication { get; }
    ILoggerService Logger { get; }
}