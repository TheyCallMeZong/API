using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Implementation
{
    public class DotNetMetricsRepository : IRepositoryDotNetMetrics
    {
        private SQLiteConnection _connection;
        public DotNetMetricsRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Create(DotNetMetrics item)
        {
            using var command = new SQLiteCommand(_connection);
            command.CommandText = @"INSERT INTO dotnetmetrics (value, fromtime, totime) VALUES (@value, @fromtime, @totime)";

            command.Parameters.AddWithValue("@value", item.Value);
            command.Parameters.AddWithValue("@fromtime", item.FromTime.TotalSeconds);
            command.Parameters.AddWithValue("@totime", item.ToTime.TotalSeconds);

            command.Prepare();
            command.ExecuteNonQuery();
        }

        public DotNetMetrics GetById(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM dotnetmetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new DotNetMetrics
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
