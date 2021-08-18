using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DOTZ.Controllers
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
        private readonly IUserSession _userSession;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserSession userSession)
        {
            _logger = logger;
            _userSession = userSession;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            var costumer = _userSession.GetCostumer();

            

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
