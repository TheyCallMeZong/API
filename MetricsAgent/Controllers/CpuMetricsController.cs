using Microsoft.AspNetCore.Mvc;
using System;
using MetricsCommon;
using Microsoft.Extensions.Logging;
using MetricsAgent.Interface;
using MetricsAgent.Data;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private IRepositoryCpuMetrics _repositoryCpuMetrics;

        private readonly ILogger<CpuMetricsController> _logger;
        public CpuMetricsController(ILogger<CpuMetricsController> logger, IRepositoryCpuMetrics repositoryCpuMetrics)
        {
            _logger = logger;
            _repositoryCpuMetrics = repositoryCpuMetrics;
        }

        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentile([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime} + {percentile}");
            _repositoryCpuMetrics.Create(new CpuMetrics
            {
                FromTime = fromTime,
                ToTime = toTime,
                Percentile = percentile
            });
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            _repositoryCpuMetrics.Create(new CpuMetrics
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            return Ok();
        }
    }
}
