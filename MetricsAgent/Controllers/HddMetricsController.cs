using MetricsAgent.DB.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private IRepositoryHddMetrics _repository;
        public HddMetricsController(ILogger<HddMetricsController> logger, IRepositoryHddMetrics repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("left")]
        public IActionResult GetFreeSpaceSize()
        {
            _logger.LogInformation("GetFreeSpaceSize in HddMetricsController");
            _repository.Create(new MetricsAgent.DB.Data.HddMetrics
            {
            });
            return Ok();
        }
    }
}
