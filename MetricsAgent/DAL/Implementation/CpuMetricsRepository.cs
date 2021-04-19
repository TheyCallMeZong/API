using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.Implementation
{
    public class CpuMetricsRepository : IRepositoryCpuMetrics
    {

        private readonly ISqlSettingsProvider _provider;

        public CpuMetricsRepository(ISqlSettingsProvider provider)
        {
            _provider = provider;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void Create(CpuMetrics item)
        {
            using var connection = new SQLiteConnection(_provider.GetConnectionString());
            connection.Execute("INSERT INTO cpumetrics (value, time) VALUES (@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time.ToUnixTimeSeconds()
                });

        }
        public IList<CpuMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using var connection = new SQLiteConnection(_provider.GetConnectionString());
            return connection
                .Query<CpuMetrics>(
                    $"SELECT id, time, value From cpumetrics WHERE time > @FromTime AND time < @ToTime",
                    new
                    {
                        FromTime = fromTime.ToUnixTimeSeconds(),
                        ToTime = toTime.ToUnixTimeSeconds()
                    })
                .ToList();
        }

        public IList<CpuMetrics> GetAll()
        {
            using var connection = new SQLiteConnection(_provider.GetConnectionString());
            var q = connection
                .Query<CpuMetrics>($"SELECT id, time, value From cpumetrics")
                .ToList();
            return q;
        }
    }
}
