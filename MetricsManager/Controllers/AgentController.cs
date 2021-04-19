using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
//создать специальный класс с суффиксом Response для всех метрик +
//также создать специальный класс Dto для всех метрик +                                                        
//еще нужен статус пользователя для методов ниже +
//специальная папка в которой я буду хранить столбцы в бдэшке +
//в базе хранить Id and URI агента +
//Implement Job 
//Инъектировать в Job репозиторий работы с агентами, репозиторий работы с соответствующей метрикой, и IMetricsAgentClient
//Интерфейсы, реализация интерфейсов, миграции, даппер
//методы в интерфейсе : Create, GetAll, GetByTimePeriod
//и в конце реализовать геты как в агенте в контроллере
//Polly and HttpClient
//по итогу у меня 2 базы
        {
            _logger.LogInformation($"на вход в пришло {agentInfo.AgentId} + {agentInfo.AgentAdress}");
            return Ok();
        }
        
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"на вход пришло {agentId}");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"на вход пришло {agentId}");
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
