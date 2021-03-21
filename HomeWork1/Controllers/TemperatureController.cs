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
        private readonly TemperatureValues temperatureValues;

        public TemperatureController(TemperatureValues temperatureValues)
        {
            this.temperatureValues = temperatureValues;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] Temperature temperatureDto)
        {

            temperatureValues.temperatures.Add(temperatureDto);

            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime DateStart, [FromQuery] DateTime DateEnd)
        {
            TemperatureValues temperatureValuesToRead = new();
            temperatureValuesToRead.temperatures = temperatureValues.temperatures
                .Where(temperature => temperature.Date >= DateStart && temperature.Date <= DateEnd)
                .Select(temperature => temperature)
                .ToList();

            return Ok(temperatureValuesToRead.temperatures);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] Temperature temperature)
        {
            foreach (var hold in temperatureValues.temperatures)
                if (hold.Date == temperature.Date)
                    hold.TemperatureC = temperature.TemperatureC;
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime DateStart, [FromQuery] DateTime DataEnd)
        {
            foreach (var e in temperatureValues.temperatures)
                if (e.Date >= DateStart && e.Date <= DataEnd)
                    temperatureValues.temperatures.Remove(e);
            return Ok();
        }

    }
}
