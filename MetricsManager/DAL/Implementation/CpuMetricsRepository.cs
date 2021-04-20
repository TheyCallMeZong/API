﻿using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsManager.DAL.Implementation
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private IGetConnection _connection;
        public CpuMetricsRepository(IGetConnection connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void Create(CpuMetrics item)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());

            connection.Execute("Insert into cpumetrics (agentid, value, time) VALUES (@agentid, @value, @time)", 
                new{
                    agentid = item.AgentId,
                    value = item.Value,
                    time = item.Time
            });

        }

        public IList<CpuMetrics> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());

            return connection
                .Query<CpuMetrics>("select * from cpumetrics where time >@fromtime and time <@totime", 
                new 
                { 
                    fromtime = fromTime.ToUnixTimeSeconds(),
                    totime = toTime.ToUnixTimeSeconds()
                })
                .ToList();
        }

        public IList<CpuMetrics> GettAll()
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());

            return connection
                .Query<CpuMetrics>("select * from cpumetrics")
                .ToList();
        }
    }
}
