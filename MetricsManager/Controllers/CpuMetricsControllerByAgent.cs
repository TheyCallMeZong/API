using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MetricsCommon;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsControllerByAgent : ControllerBase
    {
        private readonly ILogger<CpuMetricsControllerByAgent> _logger;

        public CpuMetricsControllerByAgent(ILogger<CpuMetricsControllerByAgent> logger)
        {
            _logger = logger;
        }

       [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentile([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, 
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"на вход пришло {agentId} + {fromTime.ToString()} + {toTime.ToString()} + {percentile}");
            return Ok();
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"на вход пришло {agentId} + {fromTime.ToString()} + { toTime.ToString()}");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime.ToString()} + {toTime.ToString()}");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime,
            [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"на вход пришло {fromTime.ToString()} + {toTime.ToString()} + {percentile}");
            return Ok();
        }

    }
}
