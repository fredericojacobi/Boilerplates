using Contracts.Services;
using Entities.DataTransferObjects.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public AuthenticationController(IServiceWrapper service) => _service = service;

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody] AuthenticationDto dto) => await _service.Authentication.Authenticate(dto);
        
    }
}