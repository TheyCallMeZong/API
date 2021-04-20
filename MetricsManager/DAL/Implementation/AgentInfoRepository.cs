using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Implementation
{
    public class AgentInfoRepository : IAgentRepository
    {
        private IGetConnection _connection;

        public AgentInfoRepository(IGetConnection connection)
        {
            _connection = connection;
        }
        public void Create(AgentInfo item)
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            connection.Execute("insert into agentinfo (uri, agent) VALUES (@uri, @agent)",
                new
                {
                    uri = item.AgentAdress,
                    agent = item.Agent
                });
        }


        public IList<AgentInfo> GettAll()
        {
            using var connection = new SQLiteConnection(_connection.GetConnection());
            return connection.Query<AgentInfo>("select * from agentinfo").ToList();
        }
    }
}
