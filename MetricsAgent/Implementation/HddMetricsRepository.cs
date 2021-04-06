using MetricsAgent.Data;
using MetricsAgent.Interface;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Implementation
{
    public class HddMetricsRepository : IRepositoryHddMetrics
    {
        private SQLiteConnection _connection;
        public HddMetricsRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Create(HddMetrics item)
        {
            using var command = new SQLiteCommand(_connection);
            command.CommandText = @"INSERT INTO hddmetics (value) VALUES (@value)";

            command.Parameters.AddWithValue("@value", item.Value);

            command.Prepare();
            command.ExecuteNonQuery();
        }
        public HddMetrics GetById(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM hddmetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new HddMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(0)
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
