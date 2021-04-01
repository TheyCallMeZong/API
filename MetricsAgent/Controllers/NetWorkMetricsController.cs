using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetWorkMetricsController : ControllerBase
    {
        private readonly ILogger<NetWorkMetricsController> _logger;
        public NetWorkMetricsController(ILogger<NetWorkMetricsController> logger)
        {
            _logger = logger;
        }
        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation("GetMetrics in NetWorkMetricsController");
            return Ok();
        }  
    }
}
