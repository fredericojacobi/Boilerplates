using Contracts.Services;
using Entities.DataTransferObjects.UserApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserApplicationController : ControllerBase
{
    private readonly ILogger<UserApplicationController> _logger;
    private readonly IServiceWrapper _service;

    public UserApplicationController(ILogger<UserApplicationController> logger, IServiceWrapper service)
    {
        _logger = logger;
        _service = service;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _service.UserApplication.GetAllAsync();
        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var result = await _service.UserApplication.GetAsync(id);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> Login(UserApplicationLoginDto dto)
    {
        return Ok(await _service.UserApplication.Authenticate(dto));
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserApplicationRegisterDto dto)
    {
        var result = await _service.UserApplication.PostAsync(dto);
        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UserApplicationUpdateDto dto)
    {
        var result = await _service.UserApplication.PutAsync(id, dto);
        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _service.UserApplication.DeleteAsync(id);
        return Ok(result);
    }
}