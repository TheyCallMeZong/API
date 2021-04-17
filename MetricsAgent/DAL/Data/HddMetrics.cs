
using System;

namespace MetricsAgent.Data
{
    public class HddMetrics
    {
        public int Id { get; set; }
        public double FreeSize { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
