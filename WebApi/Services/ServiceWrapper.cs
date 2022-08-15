using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;

namespace Services;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    private IUserApplicationService _userApplication;

    public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IUserApplicationService UserApplication => _userApplication ??= new UserApplicationService(_repository, _mapper);
}