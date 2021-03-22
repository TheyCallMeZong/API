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
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureValues _temperatureValues;
        public TemperatureController(TemperatureValues temperatureValues)
        {
            _temperatureValues = temperatureValues;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] Temperature temperatureDto)
        {
            _temperatureValues.temperatures.Add(temperatureDto);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime dateStart, [FromQuery] DateTime dateEnd)
        {
            var temperatureValuesToRead = _temperatureValues.temperatures
                .Where(temperature => temperature.Date >= dateStart && temperature.Date <= dateEnd)
                .ToList();
            return Ok(temperatureValuesToRead);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] Temperature temperature)
        {
            foreach (var hold in _temperatureValues.temperatures)
            {
                if (hold.Date == temperature.Date)
                {
                    hold.TemperatureC = temperature.TemperatureC;
                }
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime dateStart, [FromQuery] DateTime dataEnd)
        {
            _temperatureValues.temperatures
                .RemoveAll(temperature => temperature.Date >= dateStart && temperature.Date <= dataEnd);
            return Ok();
        }
    }
}