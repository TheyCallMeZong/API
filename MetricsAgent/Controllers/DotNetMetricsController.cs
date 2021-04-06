using MetricsAgent.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private IRepositoryDotNetMetrics _repository;
        private readonly ILogger<DotNetMetricsController> _logger;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IRepositoryDotNetMetrics repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrors([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _repository.Create(new MetricsAgent.Data.DotNetMetrics
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            return Ok();
        }
    }
}
