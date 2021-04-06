using Dapper;
using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;

namespace MetricsAgent.Implementation
{
    public class CpuMetricsRepository : IRepositoryCpuMetrics
    {
        private const string _connection = @"Data Source= cpumetrics; Version=3;Pooling=True;Max Pool Size=100;";
        public void Create(CpuMetrics item)
        {
            using (var connection = new SQLiteConnection(_connection))
            {
                connection.Execute("INSERT INTO cpumetrics(value, fromtime, totime) VALUES (@value, @fromtime, @totime)",
                    new
                    {
                        value = item.Value,
                        fromtime = item.FromTime.TotalSeconds,
                        totime = item.ToTime.TotalSeconds
                    });
            };
        }
        public int GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {

            using (var connection = new SQLiteConnection(_connection))
            {
                return connection.QuerySingle<int>("SELECT value FROM cpumetrics WHERE fromtime = @fromtime and totime =@totime",
                    new
                    {
                        fromtime = fromTime.TotalSeconds,
                        totime = toTime
                    });
            };
        }
    }
}
