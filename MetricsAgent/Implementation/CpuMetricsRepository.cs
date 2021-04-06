using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Data.SQLite;

namespace MetricsAgent.Implementation
{
    public class CpuMetricsRepository : IRepositoryCpuMetrics
    {
        private SQLiteConnection _connection;
        public CpuMetricsRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Create(CpuMetrics item)
        {
            using var command = new SQLiteCommand(_connection);
            command.CommandText = @"INSERT INTO cpumetrics (value, fromtime, totime, percentile) VALUES (@value, @fromtime, @totime, @percentile)";

            command.Parameters.AddWithValue("@value", item.Value);
            command.Parameters.AddWithValue("@fromtime", item.FromTime.TotalSeconds);
            command.Parameters.AddWithValue("@totime", item.ToTime.TotalSeconds);
            command.Parameters.AddWithValue("@percentile", item.Percentile);

            command.Prepare();
            command.ExecuteNonQuery();
        }
        public CpuMetrics GetById(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM cpumetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new CpuMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(0),
                        FromTime = TimeSpan.FromSeconds(reader.GetInt32(0)),
                        ToTime = TimeSpan.FromSeconds(reader.GetInt32(0))
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
