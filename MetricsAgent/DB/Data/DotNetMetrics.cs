using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.Data
{
    public class DotNetMetrics
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
    }
}
