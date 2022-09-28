using Microsoft.AspNetCore.Mvc;

namespace SuperAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            _logger.LogInformation("Sample executing... {name}",name);
            return Ok(name);
        }

      
    }
}