using MetricsCommon;
using System;

namespace MetricsAgent.Data
{
    public class CpuMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public Percentile Percentile { get; set; }
    }
}
