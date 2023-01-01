﻿using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;

namespace Services;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;
    
    private IUserApplicationService _userApplication;
    private ILoggerService _logger;
    private IAuthenticationService _authentication;
    
    public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IUserApplicationService UserApplication => _userApplication ??= new UserApplicationService(_logger ?? Logger, _repository, _mapper);
    public ILoggerService Logger => _logger ??= new LoggerService(_repository);
    public IAuthenticationService Authentication => _authentication ??= new AuthenticationService(_logger ?? Logger, _repository);
}