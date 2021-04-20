using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    /// <summary>
    /// используем в качестве запроса
    /// </summary>
    public class CpuMetricsRequest
    {
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }
        public string Adress { get; set; }
    }
}
