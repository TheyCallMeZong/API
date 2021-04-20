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
    public class NetWorkMetricsRepository : INetWorkMetricsRepository
    {
        private IGetConnection _connection;

        public NetWorkMetricsRepository(IGetConnection connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void Create(NetWorkMetrics item)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            connection.Execute("insert into networkmetrics (agentid, value, time) VALUES (@agentid, @value, @time)",
                new
                {
                    agentid = item.AgentId,
                    value = item.Value,
                    time = item.Time
                });
        }

        public IList<NetWorkMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            return connection.Query<NetWorkMetrics>("select * from networkmetrics where time >@fromtime and time < @totime",
                new
                {
                    fromtime = fromTime.ToUnixTimeSeconds(),
                    totime = toTime.ToUnixTimeSeconds()
                }).ToList();
        }

        public IList<NetWorkMetrics> GettAll()
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            return connection.Query<NetWorkMetrics>("select * from networkmetrics").ToList();
        }
    }
}
