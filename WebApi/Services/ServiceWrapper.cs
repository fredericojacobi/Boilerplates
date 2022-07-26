using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;

namespace Services;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    private IUserAplicationService _userApplication;

    public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IUserAplicationService UserApplication => _userApplication ??= new UserApplicationService(_repository, _mapper);
}