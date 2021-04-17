using AutoMapper;
using MetricsAgent.Data;
using MetricsAgent.Requests;

namespace MetricsAgent.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetrics, CpuMetrcisDto>();
            CreateMap<DotNetMetrics, DotNetMetricDto>();
            CreateMap<HddMetrics, HddMetricDto>();
            CreateMap<NetWorkMetrics, NetWorkMetricDto>();
            CreateMap<RamMetrics, RamMetricDto>();
        }
    }
}
