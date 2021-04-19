using System;

namespace MetricsManager.Models
{
    public class AgentInfo
    {
        public int AgentId { get; } 
        public Uri AgentAdress { get; }
        public bool Status { get; }
    }
}
