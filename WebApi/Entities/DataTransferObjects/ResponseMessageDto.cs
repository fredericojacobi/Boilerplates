using System.Net;

namespace Entities.DataTransferObjects;

public class ResponseMessageDto<T> where T : class
{
    public HttpStatusCode Status { get; }
    
    public bool Error { get; }
    
    public string? Message { get; }
    
    public IEnumerable<T>? Records { get; }

    public int Count => Records?.Count() ?? 0;

    public ResponseMessageDto(HttpStatusCode status, bool error, string? message, IEnumerable<T>? records)
    {
        Status = status;
        Error = error;
        Message = message;
        Records = records;
    }
}