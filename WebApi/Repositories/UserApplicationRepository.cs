using Contracts.Repositories;
using Entities.Models;
using Generics.Extensions;
using Generics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class UserApplicationRepository : IUserApplicationRepository
{
    private readonly UserManager<UserApplication> _userManager;

    public UserApplication? CurrentUser { get; }

    public UserApplicationRepository(UserManager<UserApplication> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;

        var currentUserId = httpContextAccessor.HttpContext?.User.Claims.Select(x => x.Value).FirstOrDefault();
        CurrentUser = ReadUserByIdAsync(currentUserId.ToGuid()).Result; 
    }
    
    public async Task<bool> ValidatePassword(UserApplication user, string password) => await _userManager.CheckPasswordAsync(user, password);

    public async Task<IEnumerable<UserApplication>> ReadAllUsersAsync() => await _userManager.Users.ToListAsync();

    public async Task<Pagination<UserApplication>> ReadAllUsersPaginatedAsync(int page, int limit)
    {
        var totalRecords = await _userManager.Users.ToListAsync();
        var result = await _userManager.Users.Skip((page - 1) * limit).Take(limit).ToListAsync();
        return new Pagination<UserApplication>(result, totalRecords.Count, page, limit);
    }

    public async Task<UserApplication?> ReadUserByIdAsync(Guid id) => await _userManager.FindByIdAsync(id.ToString());

    public async Task<UserApplication?> ReadUserByUserNameAsync(string username) => await _userManager.FindByNameAsync(username);

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

    public async Task<IdentityResult> DeleteUserAsync(UserApplication user) => await _userManager.DeleteAsync(user);

    public async Task<IdentityResult> DeleteUserAsync(Guid id)
    {
        var user = await ReadUserByIdAsync(id);
        return await DeleteUserAsync(user);
    }
}