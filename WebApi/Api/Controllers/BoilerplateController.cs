using Contracts.Services;
using Generics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoilerplateController : ControllerBase
{
    private readonly IServiceWrapper _service;
    private ResponseMessage<dynamic> _responseMessage;

    public BoilerplateController(IServiceWrapper service) => _service = service;

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<ActionResult> Get() => _responseMessage.Ok(new { });

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<ActionResult> Post() => _responseMessage.Ok(new { });

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut]
    public async Task<ActionResult> Put() => _responseMessage.Ok(new { });

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete]
    public async Task<ActionResult> Delete() => _responseMessage.Ok(new { });
}