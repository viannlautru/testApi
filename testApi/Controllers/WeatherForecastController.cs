using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using testApi.Model;

namespace testApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("api/GetCodesPiecesImportes")]
        public void GetCodesPiecesImportes(string id,string cServeur,string cBase)
        {
            ValiderInitialisation.GetValiderInitialisation(id, cServeur, cBase);
        }
        [HttpPost("api/test")]
        public string test()
        {
            var contentString = Request.Form["RefTraitement"];
            //Valeur client = JsonConvert.DeserializeObject<Valeur>(contentString);
            return contentString;
        }
    }
}