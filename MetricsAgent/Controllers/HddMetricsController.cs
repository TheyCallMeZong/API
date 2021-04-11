using AutoMapper;
using MetricsAgent.Data;
using MetricsAgent.Interface;
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

        private IMapper _mapper;
        public HddMetricsController(ILogger<HddMetricsController> logger, IRepositoryHddMetrics repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("left")]
        public IActionResult GetFreeSpaceSize()
        {
            _logger.LogInformation("GetFreeSpaceSize in HddMetricsController");

            return Ok();
        }
    }
}
