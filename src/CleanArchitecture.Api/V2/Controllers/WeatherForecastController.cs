using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Api.ApiContstants;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Api.V2.Controllers
{
    [Route("api/" + ApiConstants.ApiName + "/v{api-version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
#pragma warning disable 1591
    public class WeatherForecastController : ControllerBase
#pragma warning restore 1591
    {
       
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGadgetService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGadgetService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
#pragma warning disable 1591
        public IEnumerable<WeatherForecast> Get()
#pragma warning restore 1591
        {
            var rng = new Random();
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
