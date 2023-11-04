using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("htc/[controller]")]
    public class HealthcheckController : ControllerBase
    {
        private readonly ILogger<HealthcheckController> _logger;

        private static readonly string[] Healthes = new[]
        { "Good", "Bad"};

        public HealthcheckController(ILogger<HealthcheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet("health")]
        public IActionResult Get()
        {
            var health = Healthes[0] ?? Healthes[1];
            _logger.LogInformation("My health is: {0}", health);
            return Ok(Healthes[0] ?? Healthes[1]);
        }
    }
}