using System.Runtime.CompilerServices;
using Entities.Enums;
using Entities.Models;

namespace Contracts.Services;

public interface ILoggerService
{
    Task Log(string message,
        LogType logType,
        Guid? userId = default,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    Task<IEnumerable<Log>> GetAll();
}