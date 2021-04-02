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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private IRepositoryRamMetrics _repository; 
        public RamMetricsController(ILogger<RamMetricsController> logger, IRepositoryRamMetrics repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("available")]
        public IActionResult GetFreeSpaceSize()
        {
            _logger.LogInformation("GetFreeSpaceSize in RamMetricsController");
            _repository.Create(new MetricsAgent.DB.Data.RamMetrics
            {
            });
            return Ok();
        }
    }
}
