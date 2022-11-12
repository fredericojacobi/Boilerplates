using System.Net;
using Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

    private ResponseMessage(HttpStatusCode status, T record)
    {
        Status = status;
        Records = new List<T> { record };
    }

    private ResponseMessage(HttpStatusCode status, IEnumerable<T>? records)
    {
        Status = status;
        Records = records;
    }

    private ResponseMessage(HttpStatusCode status, string? message)
    {
        Status = status;
        Message = message;
        Records = new List<T>();
    }

    private ResponseMessage(HttpStatusCode status, string? message, IEnumerable<T>? records)
    {
        Status = status;
        Message = message;
        Records = records;
    }

    private ResponseMessage(HttpStatusCode status, string? message, T record)
    {
        Status = status;
        Message = message;
        Records = new List<T> { record };
    }

    public ActionResult Ok(T record) => new OkObjectResult(new ResponseMessage<T>(HttpStatusCode.OK, record));

    public ActionResult Ok(IEnumerable<T>? records) =>
        new OkObjectResult(new ResponseMessage<T>(HttpStatusCode.OK, records));

    public ActionResult BadRequest(string? message = "") =>
        new BadRequestObjectResult(new ResponseMessage<T>(HttpStatusCode.BadRequest, message));

    public ActionResult NotFound(string? message = "") =>
        new NotFoundObjectResult(new ResponseMessage<T>(HttpStatusCode.NotFound, message));

    public ActionResult Unauthorized(string? message = "") =>
        new UnauthorizedObjectResult(new ResponseMessage<T>(HttpStatusCode.Unauthorized, message));

    public ActionResult MethodNotAllowed() =>
        new OkObjectResult(new ResponseMessage<T>(HttpStatusCode.MethodNotAllowed, "Sorry, this method isn't allowed."));

    public ActionResult InternalServerError(Exception exception) =>
        new OkObjectResult(new ResponseMessage<T>(HttpStatusCode.InternalServerError, exception.FormatLogMessage()));

    public ActionResult IdentityResultMessage(IdentityResult? identityResult, string? successMessage = "Success")
    {
        if (identityResult is not null && !identityResult.Succeeded)
        {
            var msg = string.Empty;
            identityResult.Errors?.ToList().ForEach(x => { msg += x.Description; });
            return new BadRequestObjectResult(new ResponseMessage<T>(HttpStatusCode.BadRequest, msg));
        }

        return new OkObjectResult(new ResponseMessage<T>(HttpStatusCode.OK, successMessage));
    }
}