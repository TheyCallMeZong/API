using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;
using Dapper;

namespace MetricsAgent.Implementation
{
    public class RamMetricsRepository : IRepositoryRamMetrics
    {
        private const string _connection = @"Data Source= cpumetrics; Version=3;Pooling=True;Max Pool Size=100;";
        public void Create(RamMetrics item)
        {
            using (var connection = new SQLiteConnection(_connection)) 
            {
                connection.Execute("insert into rammetrics (value, fromtime, totime) values (@value, @fromtime, @totime)",
                    new
                    {
                        value = item.Value,
                        fromtime = item.FromTime.TotalSeconds,
                        totime = item.ToTime.TotalSeconds
                    });
            };
        }

        public RamMetrics GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using (var connection = new SQLiteConnection(_connection))
            {
                return connection.QuerySingle<RamMetrics>("select * from rammetrics where fromtime = @fromtime and totime =@totime",
                    new
                    {
                        fromtime = fromTime.TotalSeconds,
                        totime = toTime.TotalSeconds
                    });
            };
        }
    }
}
