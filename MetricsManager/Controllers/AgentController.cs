using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;
        public AgentController(ILogger<AgentController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult RegistAgent([FromQuery] AgentInfo agentInfo)
        {
            _logger.LogInformation("regist agent");
            return Ok();
        }
        
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation("enable agent");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation("disable agent");
            return Ok();
        }

        [HttpGet("allagent")]
        public IActionResult GetAllAgent()
        {
            _logger.LogInformation("All agent");
            return Ok();
        }
    }
}
