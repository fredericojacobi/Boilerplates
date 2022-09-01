using System.Net;
using Extensions;
using Microsoft.AspNetCore.Identity;

namespace Generics.Models;

public class ResponseMessage<T>
{
    public HttpStatusCode Status { get; }

    public bool Error => (int)Status >= 400;

    public string? Message { get; }

    public IEnumerable<T>? Records { get; }

    public int Count => Records?.Count() ?? 0;

    public ResponseMessage()
    {
    }

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
        Records = new List<T>();
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

    public ResponseMessage<T> Ok(T record) => new(HttpStatusCode.OK, record);
    
    public ResponseMessage<T> Ok(IEnumerable<T>? records) => new(HttpStatusCode.OK, records);

    public ResponseMessage<T> BadRequest(string? message = "") => new(HttpStatusCode.BadRequest, message);

    public ResponseMessage<T> NotFound(string? message = "") =>  new(HttpStatusCode.NotFound, message);

    public ResponseMessage<T> Unauthorized(string? message = "") => new(HttpStatusCode.Unauthorized, message);

    public ResponseMessage<T> InternalServerError(Exception exception) =>
        new(HttpStatusCode.InternalServerError, exception.FormatLogMessage());

    public ResponseMessage<bool> IdentityResultMessage(IdentityResult? identityResult, string? successMessage = "Success")
    {
        if (identityResult is not null && !identityResult.Succeeded)
        {
            var msg = string.Empty;
            identityResult.Errors?.ToList().ForEach(x => { msg += x.Description; });
            return new (HttpStatusCode.BadRequest, msg);
        }
        
        return new (HttpStatusCode.OK, successMessage);
    }
}