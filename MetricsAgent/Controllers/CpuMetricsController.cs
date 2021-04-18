using Microsoft.AspNetCore.Mvc;
using System;
using MetricsCommon;
using Microsoft.Extensions.Logging;
using MetricsAgent.Interface;
using AutoMapper;
using MetricsAgent.Data;
using System.Collections.Generic;
using MetricsAgent.Requests;

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

        /// <summary>
        /// Получение всех CPU метрик 
        /// </summary>
        /// <returns>Все метрики</returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var metrics = _repositoryCpuMetrics.GetAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetrcisDto>()
            };

            foreach (var metric in metrics)
                response.Metrics.Add(_mapper.Map<CpuMetrcisDto>(metric));

            _logger.LogInformation($"Запрос всех метрик Cpu");

            return Ok(response);
        }
        /// <summary>
        /// Собирать метрики в определенном диапозоне
        /// </summary>
        /// <param name="fromTime">начальное время</param>
        /// <param name="toTime">конечное время</param>
        /// <param name="percentile"></param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentile([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"На выход пришло {fromTime} - {toTime}");
            IList<CpuMetrics> metrcis = _repositoryCpuMetrics.GetByTimePeriod(fromTime, toTime);
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetrcisDto>()
            };
            foreach (var e in metrcis)
            {
                response.Metrics.Add(_mapper.Map<CpuMetrcisDto>(e));
            }

            return Ok(response);
        }
        /// <summary>
        /// Собирать метрики в определенном диапозоне
        /// </summary>
        /// <param name="fromTime">начальное время</param>
        /// <param name="toTime">конечное время.</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"на вход пришло {fromTime} + {toTime}");
            IList<CpuMetrics> metrcis = _repositoryCpuMetrics.GetByTimePeriod(fromTime, toTime);
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetrcisDto>()
            };
            foreach (var e in metrcis)
            {
                response.Metrics.Add(_mapper.Map<CpuMetrcisDto>(e));
            }
            return Ok(response);
        }
    }
}
