﻿using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly AppDbContext _context;
    private readonly UserManager<UserApplication> _userManager;
    private IUserApplicationRepository _userApplication;

    public RepositoryWrapper(AppDbContext context, UserManager<UserApplication> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IUserApplicationRepository UserApplication => _userApplication ??= new UserApplicationRepository(_context, _userManager);
}