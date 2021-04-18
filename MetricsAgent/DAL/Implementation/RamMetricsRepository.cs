using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MetricsAgent.DAL;

namespace MetricsAgent.Implementation
{
    public class RamMetricsRepository : IRepositoryRamMetrics
    {
        private ISqlSettingsProvider _provider;

        public RamMetricsRepository(ISqlSettingsProvider provider)
        {
            _provider = provider;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void Create(RamMetrics item)
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString())) 
            {
                connection.Execute("insert into rammetrics (available, time) values (@available, @time)",
                    new
                    {
                        available = item.Available,
                        time = item.Time.ToUnixTimeSeconds()
                    });
            };
        }

        public IList<RamMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString()))
            {
                return connection.Query<RamMetrics>("select * from rammetrics where time > @fromtime and time <@totime",
                    new
                    {
                        fromtime = fromTime.ToUnixTimeSeconds(),
                        totime = toTime.ToUnixTimeSeconds()
                    })
                    .ToList();
            };
        }

        public IList<RamMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(_provider.GetConnectionString())) {
                return connection.Query<RamMetrics>("SELECT * from rammetrics").ToList();
            };
        }
    }
}
