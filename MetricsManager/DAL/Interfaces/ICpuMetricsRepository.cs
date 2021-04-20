using MetricsManager.Models;
using System;
using System.Collections.Generic;

namespace MetricsManager.DAL.Interfaces
{
    interface ICpuMetricsRepository 
        : IRepository<CpuMetrics>
    {
        IList<CpuMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
