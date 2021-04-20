using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    interface IRamMetricsRepository
        : IRepository<RamMetrics>
    {
        IList<RamMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
