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
    public class NetWorkRepository : IRepositoryNetWorkMetrics
    {
        private ISqlSettingsProvider _provider;

        public NetWorkRepository(ISqlSettingsProvider provider)
        {
            _provider = provider;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void Create(NetWorkMetrics item)
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString()))
            {
                connection.Execute("insert into networkmetrics (value, time) values (@value, @time)", 
                    new { 
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds()
                    });
            };
        }
        public IList<NetWorkMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString()))
            {
                return connection.Query<NetWorkMetrics>("select * from networkmetrics where time > @fromtime and time <@totime",
                    new
                    {
                        fromtime = fromTime.ToUnixTimeSeconds(),
                        totime = toTime.ToUnixTimeSeconds()
                    })
                    .ToList();
            };
        }

        public IList<NetWorkMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString()))
            {
                return connection.Query<NetWorkMetrics>("SELECT * From networkmetrics").ToList();
            };
        }
    }
}
