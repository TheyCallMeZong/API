using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    public class AgentInfoRequest
    {
        public Uri AgentAdress { get; set; }
        public int Agent { get; set; }
    }
}
