using MetricsManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL
{
    public class SqlSettingsProvider : IGetConnection
    {
        public string GetConnection()
        {
            return @"Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        }
    }
}
