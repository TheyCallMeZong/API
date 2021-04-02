using MetricsAgent.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepositoryHddMetrics 
        : IRepository<HddMetrics>
    {
    }

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
        

        public void Delete(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "DELETE FROM hddmetics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<HddMetrics> GetAll()
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM hddmetrics";
            var returnList = new List<HddMetrics>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new HddMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(0),
                    });
                }
            }
            return returnList;
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

        public void Update(HddMetrics item)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "UPDATE hddmetrics SET value = @value WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
