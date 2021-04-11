using AutoMapper;
using MetricsAgent.Data;

namespace MetricsAgent.Mapper
{
    public class CpuAutoMapper : Profile
    {
        public CpuAutoMapper()
        {
            CreateMap<CpuMetrics, CpuMetricsDto>();
        }
    }
}
