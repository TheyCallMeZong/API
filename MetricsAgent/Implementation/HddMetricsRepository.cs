using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;
using Dapper;

namespace MetricsAgent.Implementation
{
    public class HddMetricsRepository : IRepositoryHddMetrics
    {
        private const string _connection = @"Data Source= cpumetrics; Version=3;Pooling=True;Max Pool Size=100;";
        public void Create(HddMetrics item)
        {
            using (var connection = new SQLiteConnection(_connection))
            {
                connection.Execute("insert into hddmetrics (value, fromtime, totime) values (@value, @fromtime, @totime)",
                    new
                    {
                        value = item.Value,
                        fromTime = item.FromTime.TotalSeconds,
                        totime = item.ToTime.TotalSeconds
                    });
            };
        }
        public int GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using (var connection = new SQLiteConnection(_connection))
            {
                return connection.QuerySingle<int>("select * from hddmetrics where fromtime =@fromtime and totime =@totime",
                    new 
                    {
                        fromtime = fromTime.TotalSeconds,
                        totime = toTime.TotalSeconds
                    });
            };
        }
    }
}
