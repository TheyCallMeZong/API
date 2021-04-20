using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    public class NetWorkMetricsRequest
    {
        public DateTimeOffset Time { get; set; }
        public int AgentId { get; set; }
    }
}
