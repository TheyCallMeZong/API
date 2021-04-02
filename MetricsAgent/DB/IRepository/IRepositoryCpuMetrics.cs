using MetricsAgent.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepositoryCpuMetrics 
        : IRepository<CpuMetrics>
    {
    }

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

        public void Delete(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "DELETE FROM cpumetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<CpuMetrics> GetAll()
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM cpumetrics";
            var returnList = new List<CpuMetrics>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new CpuMetrics
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
        public void Update(CpuMetrics item)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "UPDATE cpumetrics SET value = @value, fromtime = @fromtime, totime = @totime WHERE id=@id;";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@fromtime", item.FromTime.TotalSeconds);
            cmd.Parameters.AddWithValue("@totime", item.ToTime.TotalSeconds);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
    }
}
