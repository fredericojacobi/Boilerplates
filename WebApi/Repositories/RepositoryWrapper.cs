using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly AppDbContext _context;
    private readonly UserManager<UserApplication> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    private IUserApplicationRepository _userApplication;
    private ILoggerRepository _logger;
    
    public RepositoryWrapper(AppDbContext context, UserManager<UserApplication> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public IUserApplicationRepository UserApplication => _userApplication ??= new UserApplicationRepository(_userManager, _httpContextAccessor);
    public ILoggerRepository Logger => _logger ??= new LoggerRepository(_context);
}