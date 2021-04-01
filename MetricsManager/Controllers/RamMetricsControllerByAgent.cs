using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsCommon;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsControllerByAgent : ControllerBase
    {
        private readonly ILogger<RamMetricsControllerByAgent> _logger;

        public RamMetricsControllerByAgent(ILogger<RamMetricsControllerByAgent> logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/{agentId}/available")]
        public IActionResult GetFreeSpaceSize([FromRoute] int agentId)
        {
            _logger.LogInformation("GetFreeSpaceSize in RamMetricsControllerByAgent");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("GetMetricsFromAllCluster in RamMetricsControllerByAgent");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime,
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation("GetMetricsByPercentileFromAllCluster in RamMetricsControllerByAgent");
            return Ok();
        }

    }
}
