using AutoMapper;
using MetricsAgent.Data;
using MetricsAgent.Implementation;
using MetricsAgent.Interface;
using MetricsAgent.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetWorkMetricsController : ControllerBase
    {
        private IRepositoryNetWorkMetrics _repository;
        private readonly ILogger<NetWorkMetricsController> _logger;
        private IMapper _mapper;
        public NetWorkMetricsController(ILogger<NetWorkMetricsController> logger, IRepositoryNetWorkMetrics repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetrics([FromRoute] DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");

            var result = _repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllnetWorkResponse()
            {
                Metrics = new List<NetWorkMetricDto>()
            };

            foreach (var e in result)
                response.Metrics.Add(_mapper.Map<NetWorkMetricDto>(e));

            return Ok(response);
        }  
    }
}
