using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Microsoft.Extensions.Logging;

namespace Services;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;
    private readonly ILogger _loggerConsole;
    
    private IUserApplicationService _userApplication;
    private ILoggerService _logger;
    private IAuthenticationService _authentication;
    
    public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper, ILogger loggerConsole)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerConsole = loggerConsole;
    }

    public IUserApplicationService UserApplication => _userApplication ??= new UserApplicationService(_logger, _repository, _mapper);
    public ILoggerService Logger => _logger ??= new LoggerService(_repository, _loggerConsole);
    public IAuthenticationService Authentication => _authentication ??= new AuthenticationService(_logger, _repository);
}