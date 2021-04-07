using AutoMapper;
using MetricsAgent.Data;

namespace MetricsAgent.Mapper
{
    public class DotNetAutoMapper : Profile
    {
        public DotNetAutoMapper()
        {
            CreateMap<DotNetMetrics, DotNetMetricsDto>();
        }
    }
}
