﻿using System.Runtime.CompilerServices;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Enums;
using Entities.Models;

namespace Services;

public class LoggerService : ILoggerService
{
    private readonly IRepositoryWrapper _repository;

    public LoggerService(IRepositoryWrapper repository) => _repository = repository;

    public async Task Log(string message,
        Guid? userId = default,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        try
        {
            await _repository.Logger.Log(new Log
            {
                LogType = LogType.Undefined,
                Path = $"{sourceFilePath}:{sourceLineNumber}",
                Method = memberName,
                Message = message,
                UserApplicationId = userId
            });
        }
        catch(Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Log>> GetAll()
    {
        try
        {
            return await _repository.Logger.ReadAllAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}