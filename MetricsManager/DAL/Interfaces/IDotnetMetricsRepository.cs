using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    interface IDotnetMetricsRepository 
        : IRepository<DotNetMetrics>
    {
        IList<DotNetMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
