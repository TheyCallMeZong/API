using MetricsAgent.Data;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricsDto> Metrics { get; set; }
    }
}
