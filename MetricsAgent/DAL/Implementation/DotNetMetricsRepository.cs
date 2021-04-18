using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;
using Dapper;
using System.Collections.Generic;
using MetricsAgent.DAL.Interfaces;
using System.Linq;
using MetricsAgent.DAL;

namespace MetricsAgent.Implementation
{
    public class DotNetMetricsRepository : IRepositoryDotNetMetrics
    {

        private ISqlSettingsProvider _provider;

        public DotNetMetricsRepository(ISqlSettingsProvider _provider)
        {
            this._provider = _provider;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void Create(DotNetMetrics item)
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString()))
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES (@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds()
                    });
            };
        }

        public IList<DotNetMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString())) {
                return connection.Query<DotNetMetrics>($"SELECT id, time, value From cpumetrics WHERE time > @FromTime AND time < @ToTime",
                    new
                    {
                        FromTime = fromTime.ToUnixTimeSeconds(),
                        ToTime = toTime.ToUnixTimeSeconds()
                    })
                    .ToList();
            };
        }

        public IList<DotNetMetrics> GetAll()
        {
            using var connection = new SQLiteConnection(_provider.GetConnectionString());
            var q = connection
                .Query<DotNetMetrics>($"SELECT id, time, value From dotnetmetrics")
                .ToList();
            return q;
        }
    }
}
