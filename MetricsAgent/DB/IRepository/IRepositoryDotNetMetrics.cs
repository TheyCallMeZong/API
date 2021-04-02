using MetricsAgent.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepositoryDotNetMetrics 
        : IRepository<DotNetMetrics>
    {
    }

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

        public void Delete(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "DELETE FROM cpumetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<DotNetMetrics> GetAll()
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM dotnetmetrics";
            var returnList = new List<DotNetMetrics>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new DotNetMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(0),
                        FromTime = TimeSpan.FromSeconds(reader.GetInt32(0)),
                        ToTime = TimeSpan.FromSeconds(reader.GetInt32(0))
                    });
                }
            }
            return returnList;
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
        public void Update(DotNetMetrics item)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "UPDATE dotnetmetrics SET value = @value, fromtime = @fromtime, totime = @totime WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@fromtime", item.FromTime.TotalSeconds);
            cmd.Parameters.AddWithValue("@totime", item.ToTime.TotalSeconds);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
    }
}
