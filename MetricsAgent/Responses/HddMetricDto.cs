using System;
using System.Collections.Generic;

namespace MetricsAgent.Requests
{
    public class HddMetricDto
    {
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public double FreeSize { get; set; }
    }

    public class AllHddResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
}
