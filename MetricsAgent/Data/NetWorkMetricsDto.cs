using System;

namespace MetricsAgent.Data
{
    public class NetWorkMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
    }
}
