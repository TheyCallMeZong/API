using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    interface IHddMetricsRepository
        : IRepository<HddMetrics>
    {
        IList<HddMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
