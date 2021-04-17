using AutoMapper;
using MetricsAgent.Interface;
using MetricsAgent.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private IRepositoryRamMetrics _repository;
        private IMapper _mapper;
        public RamMetricsController(ILogger<RamMetricsController> logger, IRepositoryRamMetrics repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("available")]
        public IActionResult GetMetricsAvailableRam()
        {
            _logger.LogInformation("GetMetricsAvailableRam in RamMetricsController");

            var result = _repository.GetAll();

            var response = new AllRamResponse() 
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var e in result)
                response.Metrics.Add(_mapper.Map<RamMetricDto>(e));

            return Ok(response);
        }
    }
}
