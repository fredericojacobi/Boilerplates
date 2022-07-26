using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Repositories;

public class UserApplicationRepository : RepositoryBase<UserApplication>, IUserApplicationRepository
{
    private readonly UserManager<UserApplication> _userManager;

    public UserApplicationRepository(AppDbContext context, UserManager<UserApplication> userManager) : base(context) =>
        _userManager = userManager;

    public async Task<IEnumerable<UserApplication>> ReadAllUsersAsync() => await ReadAllAsync();

    public async Task<UserApplication> ReadUserAsync(int id) => await _userManager.FindByIdAsync(id.ToString());

    public async Task<UserApplication> ReadUserByUserNameAsync(string username) =>
        await _userManager.FindByNameAsync(username);

    public async Task<bool> CreateUserAsync(UserApplication user, string password)
    {
        var identityResult = await _userManager.CreateAsync(user, password);
        return identityResult.Succeeded;
    }

    public async Task<bool> UpdateUserAsync(UserApplication user)
    {
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(UserApplication user)
    {
        var identityResult = await _userManager.DeleteAsync(user);
        return identityResult.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await ReadUserAsync(id);
        return await DeleteUserAsync(user);
    }
}