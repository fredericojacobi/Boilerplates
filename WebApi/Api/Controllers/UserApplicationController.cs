﻿using Contracts.Services;
using Entities.DataTransferObjects.UserApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserApplicationController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public UserApplicationController(IServiceWrapper service) => _service = service;

    [HttpGet("all")]
    public async Task<ActionResult> GetAll() => await _service.UserApplication.GetAllAsync(0, 0);

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<ActionResult> GetPaginated([FromQuery] int page = 0, [FromQuery] int limit = 0) => await _service.UserApplication.GetAllAsync(page, limit);

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id) => await _service.UserApplication.GetAsync(id);

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<ActionResult> SignUp([FromBody] UserApplicationRegisterDto dto) => await _service.UserApplication.PostAsync(dto);

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UserApplicationUpdateDto dto) => await _service.UserApplication.PutAsync(id, dto);

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id) => await _service.UserApplication.DeleteAsync(id);
}