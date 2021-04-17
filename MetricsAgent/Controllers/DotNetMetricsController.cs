using AutoMapper;
using MetricsAgent.Interface;
using MetricsAgent.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private IRepositoryDotNetMetrics _repository;

        private readonly ILogger<DotNetMetricsController> _logger;

        private IMapper _mapper;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IRepositoryDotNetMetrics repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrors([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");

            var result = _repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllDotNetResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in result)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            return Ok(response);
        }
    }
}
