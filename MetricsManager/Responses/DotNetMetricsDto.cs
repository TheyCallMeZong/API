using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class DotNetMetricsDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
        public int AgentId { get; set; }
    }
    public class AllDotNetMetricsResponse
    {
        public List<DotNetMetricsDto> Metrics { get; set; }
    }
}
