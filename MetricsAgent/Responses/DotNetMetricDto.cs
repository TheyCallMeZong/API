using System;
using System.Collections.Generic;

namespace MetricsAgent.Requests
{
    public class DotNetMetricDto
    {
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
    }

    public class AllDotNetResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }
}
