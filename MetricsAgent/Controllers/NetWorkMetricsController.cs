using AutoMapper;
using MetricsAgent.Data;
using MetricsAgent.Interface;
using MetricsAgent.Responses;
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
        private IMapper _mapper;
        public NetWorkMetricsController(ILogger<NetWorkMetricsController> logger, IRepositoryNetWorkMetrics repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            NetWorkMetrics netWork = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new AllNetWorkMetricsResponse()
            {
                Metrics = new System.Collections.Generic.List<NetWorkMetricsDto>()
            };
            response.Metrics.Add(_mapper.Map<NetWorkMetricsDto>(netWork));
            return Ok(response);
        }  
    }
}
