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

    public BoilerplateController(IServiceWrapper service) => _service = service;

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<ActionResult> Get() => Ok(new ResponseMessage<bool>().MethodNotAllowed());

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<ActionResult> Post() => Ok(new ResponseMessage<bool>().MethodNotAllowed());

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut]
    public async Task<ActionResult> Put() => Ok(new ResponseMessage<bool>().MethodNotAllowed());

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete]
    public async Task<ActionResult> Delete() => Ok(new ResponseMessage<bool>().MethodNotAllowed());
}