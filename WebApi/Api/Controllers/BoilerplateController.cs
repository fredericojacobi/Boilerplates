using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoilerplateController : ControllerBase
{
    private readonly ILogger<BoilerplateController> _logger;
    private readonly IServiceWrapper _service;

    public BoilerplateController(ILogger<BoilerplateController> logger, IServiceWrapper service)
    {
        _logger = logger;
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult> Get() => throw new NotImplementedException();

    [HttpPost]
    public async Task<ActionResult> Post() => throw new NotImplementedException();

    [HttpPut]
    public async Task<ActionResult> Put() => throw new NotImplementedException();

    [HttpDelete]
    public async Task<ActionResult> Delete() => throw new NotImplementedException();
}