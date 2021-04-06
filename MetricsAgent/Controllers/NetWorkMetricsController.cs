using MetricsAgent.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetWorkMetricsController : ControllerBase
    {
        private IRepositoryNetWorkMetrics _repository;
        private readonly ILogger<NetWorkMetricsController> _logger;
        public NetWorkMetricsController(ILogger<NetWorkMetricsController> logger, IRepositoryNetWorkMetrics repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            _repository.Create(new MetricsAgent.Data.NetWorkMetrics
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            return Ok();
        }  
    }
}
