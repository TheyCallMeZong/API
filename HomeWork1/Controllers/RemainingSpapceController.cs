using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1.Controllers
{
    [Route("api/metrics")]
    [ApiController]
    public class RemainingSpapceController : ControllerBase
    {
        [HttpGet("hdd/left")]
        public IActionResult GetRemainingSpapce()
        {
            return Ok();
        }

        [HttpGet("ram/available")]
        public IActionResult GetRemainingSpapceRam()
        {
            return Ok();
        }
    }
}
