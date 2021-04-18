using System;
using System.Collections.Generic;

namespace MetricsAgent.Requests
{
    public class CpuMetrcisDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }

    public class AllCpuMetricsResponse
    {
        public List<CpuMetrcisDto> Metrics { get; set; }
    }
}
