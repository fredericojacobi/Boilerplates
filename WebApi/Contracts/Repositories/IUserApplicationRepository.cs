﻿using Entities.Models;

namespace Contracts.Repositories;

public interface IUserApplicationRepository : IRepositoryBase<UserApplication>
{
    Task<IEnumerable<UserApplication>> ReadAllUsersAsync();
    Task<UserApplication> ReadUserByIdAsync(Guid id);
    Task<UserApplication> ReadUserByUserNameAsync(string username);
    Task<bool> CreateUserAsync(UserApplication user, string password);
    Task<bool> UpdateUserAsync(UserApplication user);
    Task<bool> DeleteUserAsync(UserApplication user);
    Task<bool> DeleteUserAsync(Guid id);
}