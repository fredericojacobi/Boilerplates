using Entities.Models;

namespace Contracts.Services;

public interface IUserAplicationService
{
    Task GetAllAsync();
    Task GetAsync(int id);
    Task PostAsync(UserApplication userDTO);
    Task PutAsync(int id, UserApplication userDTO);
    Task DeleteAsync(int id);
}