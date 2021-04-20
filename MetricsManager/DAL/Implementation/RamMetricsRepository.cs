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
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private IGetConnection _connection;
        public RamMetricsRepository(IGetConnection connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void Create(RamMetrics item)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());

            connection.Execute("Insert into rammetrics (agentid, value, time) VALUES (@agentid, @value, @time)",
                new
                {
                    agentid = item.AgentId,
                    value = item.Value,
                    time = item.Time
                });

        }

        public IList<RamMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());

            return connection
                .Query<RamMetrics>("select * from rammetrics where time >@fromtime and time <@totime",
                new
                {
                    fromtime = fromTime.ToUnixTimeSeconds(),
                    totime = toTime.ToUnixTimeSeconds()
                })
                .ToList();
        }

        public IList<RamMetrics> GettAll()
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());

            return connection
                .Query<RamMetrics>("select * from rammetrics")
                .ToList();
        }
    }
}
