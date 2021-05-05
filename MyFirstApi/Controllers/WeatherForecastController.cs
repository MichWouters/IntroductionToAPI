using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstApi.MakingAPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMainClass _mainClass;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMainClass mainClass)
        {
            _logger = logger;
            _mainClass = mainClass;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Jakkamakka()
        {
            var rng = new Random();
            return Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public string AddStuff()
        {
            return "stuff added";
        }

        [HttpDelete]
        public string DeleteStuff()
        {
            return "stuff Deleted";
        }
    }
}
