using System.Runtime.CompilerServices;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Enums;
using Entities.Models;

namespace Services;

public class LoggerService : ILoggerService
{
    private readonly IRepositoryWrapper _repository;

    public LoggerService(IRepositoryWrapper repository) => _repository = repository;

    public async Task LogAsync(string message,
        LogType logType,
        Guid? userId = default,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        var log = new Log
        {
            Message = message,
            LogType = logType,
            UserApplicationId = userId,
            FileDetailsPath = Generics.Constants.Path.LogsPath,
            Method = memberName,
            Path = $"{sourceFilePath}:{sourceLineNumber}"
        };
        await _repository.Logger.Log(log);
        log.CreateFileDetails(Generics.Constants.Path.LogsPath);
    }

    public async Task<IEnumerable<Log>> GetAll() => await _repository.Logger.ReadAllAsync();
}