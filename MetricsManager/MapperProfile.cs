using AutoMapper;
using MetricsManager.Models;
using MetricsManager.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AgentInfo, AgentInfoDto>();
            CreateMap<CpuMetrics, CpuMetricsDto>();
            CreateMap<DotNetMetrics, DotNetMetricsDto>();
            CreateMap<HddMetrics, HddMetricsDto>();
            CreateMap<NetWorkMetrics, NetWorkMetricsDto>();
            CreateMap<RamMetrics, RamMetricsDto>();
        }
    }
}
