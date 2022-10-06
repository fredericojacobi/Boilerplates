using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories;

public interface IUserApplicationRepository
{
    Task<bool> ValidatePassword(UserApplication user, string password);
    Task<IEnumerable<UserApplication>> ReadAllUsersAsync();
    Task<UserApplication> ReadUserByIdAsync(Guid id);
    Task<UserApplication> ReadUserByUserNameAsync(string username);
    Task<IdentityResult> CreateUserAsync(UserApplication user, string password);
    Task<IdentityResult> UpdateUserAsync(UserApplication user);
    Task<IdentityResult> DeleteUserAsync(UserApplication user);
    Task<IdentityResult> DeleteUserAsync(Guid id);
}