using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
    //как я понял, нужно еще создать класс в котором будет храниться список пользователей List<AgentInfo>();, а в данном контроллере создать экземпляр этого класса.
    //И каждый раз когда мы будем регестрировать или что то делать 
    //в этом контроллере нужно будет вызывать конструктор, в котором будем заполять лист Агентов
    // public AgentController(AgentInfo agentInfo){ (наша локальная переменная с листом агентов) = agentInfo; } примерно так
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
    }
}
