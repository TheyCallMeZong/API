using MetricsAgent.DB.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _repository.Create(new MetricsAgent.DB.Data.DotNetMetrics
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            return Ok();
        }
    }
}
