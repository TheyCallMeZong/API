using MetricsCommon;
using System;

namespace MetricsAgent.Data
{
    public class CpuMetrics
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
