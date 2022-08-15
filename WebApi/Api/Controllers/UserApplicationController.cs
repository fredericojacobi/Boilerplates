using Contracts.Services;
using Entities.DataTransferObjects.UserApplication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserApplicationController : ControllerBase
{
    private readonly ILogger<UserApplicationController> _logger;
    private readonly IServiceWrapper _service;

    public UserApplicationController(ILogger<UserApplicationController> logger, IServiceWrapper service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> Get() => Ok(await _service.UserApplication.GetAllAsync());
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id) => Ok(await _service.UserApplication.GetAsync(id));

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserApplicationRegisterDto dto) => Ok(await _service.UserApplication.PostAsync(dto));

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UserApplicationUpdateDto dto) => Ok(await _service.UserApplication.PutAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id) => Ok(await _service.UserApplication.DeleteAsync(id));
}