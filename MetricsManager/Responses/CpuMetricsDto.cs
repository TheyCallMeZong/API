using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class CpuMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }

    public class AllCpuMetricsResponses
    {
        public List<CpuMetricsDto> Metrics { get; set; }
    }
}
