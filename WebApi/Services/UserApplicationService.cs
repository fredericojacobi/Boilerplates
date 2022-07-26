using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Services;

public class UserApplicationService : IUserAplicationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public UserApplicationService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task PostAsync(UserApplication userDTO)
    {
        throw new NotImplementedException();
    }

    public async Task PutAsync(int id, UserApplication userDTO)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}