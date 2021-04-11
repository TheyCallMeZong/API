using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;
using Dapper;

namespace MetricsAgent.Implementation
{
    public class DotNetMetricsRepository : IRepositoryDotNetMetrics
    {
        private const string _connection = @"Data Source= cpumetrics; Version=3;Pooling=True;Max Pool Size=100;";
        public void Create(DotNetMetrics item)
        {
            using (var connection = new SQLiteConnection(_connection))
            {
                connection.Execute("insert into dotnetmetrics (value, fromtime, totime) VALUES (@value, @fromtime, @totime)", 
                    new { 
                    value = item.Value,
                    fromtime = item.FromTime.TotalSeconds,
                    totime = item.ToTime.TotalSeconds
                });
            };
        }

        public DotNetMetrics GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using (var connection = new SQLiteConnection(_connection))
            {
                return connection.QuerySingle<DotNetMetrics>("select * from dotnetmetrics where fromtime = @fromtime and totime =@totime",
                    new {
                        fromtime = fromTime.TotalSeconds,
                        toTime = toTime.TotalSeconds
                    });
            };
        }
    }
}
