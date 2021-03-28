using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, TimeSpan toTime)
        {
            return Ok();
        }  
    }
}
