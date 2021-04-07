using AutoMapper;
using MetricsAgent.Data;
using MetricsAgent.Interface;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
        public IActionResult GetErrors([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            DotNetMetrics dotNetMetrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new System.Collections.Generic.List<DotNetMetricsDto>()
            };
            response.Metrics.Add(_mapper.Map<DotNetMetricsDto>(dotNetMetrics));
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            return Ok();
        }
    }
}
