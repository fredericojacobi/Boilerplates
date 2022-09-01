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

    public async Task<bool> ValidatePassword(UserApplication user, string password) =>
        await _userManager.CheckPasswordAsync(user, password);

    public async Task<IEnumerable<UserApplication>> ReadAllUsersAsync() => await ReadAllAsync();

    public async Task<UserApplication> ReadUserByIdAsync(Guid id) => await _userManager.FindByIdAsync(id.ToString());

    public async Task<UserApplication> ReadUserByUserNameAsync(string username) =>
        await _userManager.FindByNameAsync(username);

    public async Task<IdentityResult> CreateUserAsync(UserApplication user, string password)
    {
        user.CreatedAt = DateTime.Now;
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> UpdateUserAsync(UserApplication user)
    {
        user.ModifiedAt = DateTime.Now;
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> DeleteUserAsync(UserApplication user)
    {
        return await _userManager.DeleteAsync(user);
    }

    public async Task<IdentityResult> DeleteUserAsync(Guid id)
    {
        var user = await ReadUserByIdAsync(id);
        return await DeleteUserAsync(user);
    }
}