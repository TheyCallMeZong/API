using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    /// <summary>
    /// используем в качестве запроса
    /// </summary>
    public class CpuMetricsRequst
    {
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
