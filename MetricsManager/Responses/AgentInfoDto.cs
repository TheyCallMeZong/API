using System;
using System.Collections.Generic;

namespace MetricsManager.Responses
{
    /// <summary>
    /// используем в качестве ответа на запрос
    /// </summary>
    public class AgentInfoDto
    {
        public int Id { get; set; }
        public Uri AgentAdress { get; set; }
    }

    public class AllAgentInfoResponses
    {
        public List<AgentInfoDto> AgentInfo { get; set; }
    }
}
