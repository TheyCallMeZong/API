﻿using System;
using System.Collections.Generic;
using MetricsManager.DAL.Models;

namespace MetricsManager.DAL.Interfaces
{
    public interface INetworkMetricsRepository : IRepository<NetworkMetricModel>
    {
        IList<NetworkMetricModel> GetMetricsFromTimeToTime(DateTimeOffset fromTime, DateTimeOffset toTime);
        IList<NetworkMetricModel> GetMetricsFromTimeToTimeFromAgent(DateTimeOffset fromTime, DateTimeOffset toTime, int idAgent);
        IList<NetworkMetricModel> GetMetricsFromTimeToTimeOrderBy(DateTimeOffset fromTime, DateTimeOffset toTime, string sortingField);
        IList<NetworkMetricModel> GetMetricsFromTimeToTimeFromAgentOrderBy(DateTimeOffset fromTime, DateTimeOffset toTime, string sortingField, int idAgent);
        DateTimeOffset LastTime();
    }
}
