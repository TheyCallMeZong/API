using AutoMapper;
using MetricsAgent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Mapper
{
    public class HddMetricsMapper : Profile
    {
        public HddMetricsMapper()
        {
            CreateMap<HddMetrics, HddMetricsDto>();
        }
    }
}
