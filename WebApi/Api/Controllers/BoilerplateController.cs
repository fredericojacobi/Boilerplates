using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoilerplateController : ControllerBase
    {
        private readonly ILogger<BoilerplateController> _logger;

        [HttpGet]
        public async Task<ActionResult> Get() => Ok();
        
        [HttpPost]
        public async Task<ActionResult> Post() => Ok();
        
        [HttpPut]
        public async Task<ActionResult> Put() => Ok();
        
        [HttpDelete]
        public async Task<ActionResult> Delete() => Ok();
    }
}
