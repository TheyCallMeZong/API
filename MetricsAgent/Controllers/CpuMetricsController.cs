using Microsoft.AspNetCore.Mvc;
using System;
using MetricsCommon;
using Microsoft.Extensions.Logging;
using MetricsAgent.Interface;
using AutoMapper;
using MetricsAgent.Data;
using MetricsAgent.Responses;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private IRepositoryCpuMetrics _repositoryCpuMetrics;

        private readonly ILogger<CpuMetricsController> _logger;

        private IMapper _mapper;
        public CpuMetricsController(ILogger<CpuMetricsController> logger, IRepositoryCpuMetrics repositoryCpuMetrics, IMapper mapper)
        {
            _logger = logger;
            _repositoryCpuMetrics = repositoryCpuMetrics;
            _mapper = mapper;
        }

        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentile([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime} + {percentile}");
            CpuMetrics cpumetric = _repositoryCpuMetrics.GetByTimePeriod(fromTime,toTime);
            var response = new AllCpuMetricsResponse() 
            {
                Metrics = new System.Collections.Generic.List<CpuMetricsDto>()
            };
            response.Metrics.Add(_mapper.Map<CpuMetricsDto>(cpumetric));
            return Ok(response);
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            CpuMetrics cpumetric = _repositoryCpuMetrics.GetByTimePeriod(fromTime, toTime);
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new System.Collections.Generic.List<CpuMetricsDto>()
            };
            response.Metrics.Add(_mapper.Map<CpuMetricsDto>(cpumetric));
            return Ok(_repositoryCpuMetrics.GetByTimePeriod(fromTime, toTime));
        }
    }
}
