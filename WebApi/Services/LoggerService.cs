using System.Runtime.CompilerServices;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Enums;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Path = Generics.Constants.Path;

namespace Services;

public class LoggerService : ILoggerService
{
    private readonly IRepositoryWrapper _repository;
    private readonly ILogger _logger;
    
    public LoggerService(
        IRepositoryWrapper repository,
        ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task LogAsync(
        string message,
        LogType logType,
        Guid? userId = default,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        try
        {
            var log = new Log
            {
                Message = message,
                LogType = logType,
                UserApplicationId = userId,
                FileDetailsPath = Path.LogsPath,
                Method = memberName,
                Path = $"{sourceFilePath}:{sourceLineNumber}"
            };

            LogConsole(log);
            await _repository.Logger.Log(log);
            log.CreateFileDetails(Path.LogsPath);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message} - {e.InnerException}");
            throw;
        }
    }
    
    public async Task<IEnumerable<Log>> GetAll() => await _repository.Logger.ReadAllAsync();

    private void LogConsole(Log log)
    {
        var jsonLogObj = JsonConvert.SerializeObject(log);
        
        switch (log.LogType)
        {
            case LogType.Error:
                _logger.LogError(jsonLogObj);
                break;
            
            case LogType.Success:
                _logger.LogInformation(jsonLogObj);
                break;
            
            case LogType.Warning:
            case LogType.Undefined:
                _logger.LogWarning(jsonLogObj);
                break;
            default:
                throw new Exception("Logtype not found");
        }
    }
}