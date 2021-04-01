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
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsControllerByAgent : ControllerBase
    {
        private readonly ILogger<HddMetricsControllerByAgent> _logger;
        public HddMetricsControllerByAgent(ILogger<HddMetricsControllerByAgent> logger)
        {
            _logger = logger;
            _logger.LogInformation("Ctor in HddMetricsControllerByAgent");
        }

        [HttpGet("agent/{agentId}/left")]
        public IActionResult GetFreeSpaceSize([FromRoute] int agentId)
        {
            _logger.LogInformation("GetFreeSpaceSize in HddMetricsControllerByAgent");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("GetMetricsFromAllCluster in HddMetricsControllerByAgent");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime,
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation("GetMetricsByPercentileFromAllCluster in HddMetricsControllerByAgent");
            return Ok();
        }

    }
}
