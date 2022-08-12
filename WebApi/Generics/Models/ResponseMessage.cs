using System.Net;

namespace Generics.Models;

public class ResponseMessage<T>
{
    private HttpStatusCode Status { get; }

    private bool Error => (int)Status >= 400;

    private string? Message { get; }

    private IEnumerable<T>? Records { get; }

    public int Count => Records?.Count() ?? 0;
    
    public ResponseMessage(HttpStatusCode status, T record)
    {
        Status = status;
        Records = new List<T> { record };
    }
    
    public ResponseMessage(HttpStatusCode status, IEnumerable<T>? records)
    {
        Status = status;
        Records = records;
    }
    
    public ResponseMessage(HttpStatusCode status, string? message)
    {
        Status = status;
        Message = message;
    }
    
    public ResponseMessage(HttpStatusCode status, string? message, IEnumerable<T>? records)
    {
        Status = status;
        Message = message;
        Records = records;
    }
    
    public ResponseMessage(HttpStatusCode status, string? message, T record)
    {
        Status = status;
        Message = message;
        Records = new List<T> { record };
    }
}