using MetricsAgent.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepositoryNetWorkMetrics 
        : IRepository<NetWorkMetrics>
    {
    }

    public class NetWorkRepository : IRepositoryNetWorkMetrics
    {
        private SQLiteConnection _connection;
        public NetWorkRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Create(NetWorkMetrics item)
        {
            using var command = new SQLiteCommand(_connection);
            command.CommandText = @"INSERT INTO hddmetics (value, fromtime, totime) VALUES (@value, @fromtime, @totime)";

            command.Parameters.AddWithValue("@value", item.Value);
            command.Parameters.AddWithValue("@fromtime", item.FromTime);
            command.Parameters.AddWithValue("@totime", item.ToTime);

            command.Prepare();
            command.ExecuteNonQuery();
        }
        public NetWorkMetrics GetById(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM networkmetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new NetWorkMetrics
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
