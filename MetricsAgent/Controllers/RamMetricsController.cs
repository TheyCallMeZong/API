using MetricsAgent.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private IRepositoryRamMetrics _repository; 
        public RamMetricsController(ILogger<RamMetricsController> logger, IRepositoryRamMetrics repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("available")]
        public IActionResult GetFreeSpaceSize()
        {
            _logger.LogInformation("GetFreeSpaceSize in RamMetricsController");
            _repository.Create(new MetricsAgent.Data.RamMetrics
            {
            });
            return Ok();
        }
    }
}
