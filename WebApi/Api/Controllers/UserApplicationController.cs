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
    public async Task<ActionResult> Get()
    {
        var result = await _service.UserApplication.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var result = await _service.UserApplication.GetAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserApplicationRegisterDto dto)
    {
        var result = await _service.UserApplication.PostAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UserApplicationUpdateDto dto)
    {
        var result = await _service.UserApplication.PutAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _service.UserApplication.DeleteAsync(id);
        return Ok(result);
    }
}