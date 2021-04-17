using System;
using System.Collections.Generic;

namespace MetricsAgent.Requests
{
    public class NetWorkMetricDto
    {
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
    }
    
    public class AllnetWorkResponse
    {
        public List<NetWorkMetricDto> Metrics { get; set; }
    }
}
