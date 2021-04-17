using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;
using Dapper;
using System.Collections.Generic;
using MetricsAgent.DAL.Interfaces;
using System.Linq;

namespace MetricsAgent.Implementation
{
    public class HddMetricsRepository : IRepositoryHddMetrics
    {
        private ISqlSettingsProvider sqlSettingsProvider;

        public HddMetricsRepository(ISqlSettingsProvider sqlSettingsProvider)
        {
            this.sqlSettingsProvider = sqlSettingsProvider;
        }
        public void Create(HddMetrics item)
        {
            using (var connection = new SQLiteConnection(sqlSettingsProvider.GetConnectionString()))
            {
                connection.Execute("insert into hddmetrics (freesize,time) values (@freesize, @time)",
                    new
                    {
                        freesize = item.FreeSize,
                        time = item.Time.ToUnixTimeSeconds()
                    });
            };
        }

        public IList<HddMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(sqlSettingsProvider.GetConnectionString()))
            {
                return connection.Query<HddMetrics>("SELECT * from hddmetrics where time >@fromTime and time <@toTime",
                    new 
                    { 
                        fromTime = fromTime.ToUnixTimeSeconds(),
                        toTime = toTime.ToUnixTimeSeconds()
                    })
                    .ToList();
            };
        }

        public IList<HddMetrics> GetAll()
        {
            using (var connection = new SQLiteConnection(sqlSettingsProvider.GetConnectionString()))
            {
                return connection.Query<HddMetrics>("SELECT * From hddmetrics").ToList();
            };
        }
    }
}
