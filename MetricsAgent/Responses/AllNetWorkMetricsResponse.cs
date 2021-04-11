using MetricsAgent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Responses
{
    public class AllNetWorkMetricsResponse
    {
        public List<NetWorkMetricsDto> Metrics { get; set; }
    }
}
