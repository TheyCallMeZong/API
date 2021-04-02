
using MetricsAgent.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepositoryRamMetrics 
        : IRepository<RamMetrics>
    {
    }
    public class RamMetricsRepository : IRepositoryRamMetrics
    {
        private SQLiteConnection _connection;
        public RamMetricsRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Create(RamMetrics item)
        {
            using var command = new SQLiteCommand(_connection);
            command.CommandText = @"INSERT INTO rammetrics (value) VALUES (@value)";

            command.Parameters.AddWithValue("@value", item.Value);

            command.Prepare();
            command.ExecuteNonQuery();
        }


        public void Delete(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "DELETE FROM RamMetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<RamMetrics> GetAll()
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM RamMetrics";
            var returnList = new List<RamMetrics>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new RamMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(0),
                    });
                }
            }
            return returnList;
        }

        public RamMetrics GetById(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM rammetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new RamMetrics
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

        public void Update(RamMetrics item)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "UPDATE ramMmetrics SET value = @value WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
