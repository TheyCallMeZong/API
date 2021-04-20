using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Implementation
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private IGetConnection _connection;
        public HddMetricsRepository(IGetConnection connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void Create(HddMetrics item)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            connection.Execute("insert into hddmetrics (agentid, value, time) VALUES (@agentid, @value, @time)",
                new
                {
                    agentid = item.AgentId,
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<HddMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            return connection.Query<HddMetrics>("SELECT * FROM hddmetrics where time >@fromtime and time <@totime",
                new
                {
                    fromtime = fromTime.ToUnixTimeSeconds(),
                    totime = toTime.ToUnixTimeSeconds()
                }).ToList();
        }

        public IList<HddMetrics> GettAll()
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            return connection.Query<HddMetrics>("SELECT * FROM hddmetrics").ToList();
        }
    }
}
