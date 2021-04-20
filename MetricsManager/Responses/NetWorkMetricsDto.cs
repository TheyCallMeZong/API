using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class NetWorkMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
        public int AgentId { get; set; }
    }

    public class AllNetWorkMetricsResponse
    {
        public List<NetWorkMetricsDto> Metrics { get; set; }
    }
}
