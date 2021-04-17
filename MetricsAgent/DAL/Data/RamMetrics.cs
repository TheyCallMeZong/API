using System;

namespace MetricsAgent.Data
{
    public class RamMetrics
    {
        public int Id { get; set; }
        public double Available { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
