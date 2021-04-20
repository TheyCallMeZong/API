using MetricsManager.Requests;
using MetricsManager.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace MetricsManager.Client
{
    public class ManagerMetricsClient : IManagerMetricsClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ManagerMetricsClient> _logger;

        public ManagerMetricsClient(HttpClient httpClient, ILogger<ManagerMetricsClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public AllCpuMetricsResponses GetAllCpuMetrics(CpuMetricsRequest cpuMetrics)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{cpuMetrics.Adress}/api/hddmetrics/from/{cpuMetrics.FromTime.ToUnixTimeSeconds()}/to/{cpuMetrics.ToTime.ToUnixTimeSeconds()}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                using var streamReader = new StreamReader(responseStream);
                var content = streamReader.ReadToEnd();
                var result = JsonSerializer.Deserialize<AllCpuMetricsResponses>(content, new JsonSerializerOptions()
                { 
                    PropertyNameCaseInsensitive = true 
                });
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllDotNetMetricsResponse GetAllDotNetMetrics(DotNetMetricsRequest dotNetMetrics)
        {
            throw new NotImplementedException();
        }

        public AllHddMetricsResponse GetAllHddMetrics(HddMetricsRequest hddMetrics)
        {
            throw new NotImplementedException();
        }

        public AllNetWorkMetricsResponse GetAllNetWorkMetrics(NetWorkMetricsRequest netWorkMetrics)
        {
            throw new NotImplementedException();
        }

        public AllRamMetricsResponse GetAllRamMetrics(RamMetricsRequest ramMetrics)
        {
            throw new NotImplementedException();
        }
    }
}
