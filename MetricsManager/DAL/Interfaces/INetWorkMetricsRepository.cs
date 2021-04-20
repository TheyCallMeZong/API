using MetricsManager.Models;
using System;
using System.Collections.Generic;

namespace MetricsManager.DAL.Interfaces
{
    interface INetWorkMetricsRepository 
        : IRepository<NetWorkMetrics>
    {
        IList<NetWorkMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
