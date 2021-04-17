using System;
using System.Collections.Generic;

namespace MetricsAgent.Requests
{
    public class RamMetricDto
    {
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public double Available { get; set; }
    }

    public class AllRamResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
}
