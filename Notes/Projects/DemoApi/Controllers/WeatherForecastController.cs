using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
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

        

        [HttpPost]
        [Route("SaveRecord")]
        public IActionResult SaveRecrod()
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                Id = 1,
                Name = "Prasanna Deshpande",
                Designation = "MS Developer"
            });
        }

        [HttpPost]
        [Route("AnotherRecord")]
        public IActionResult AnotherRecord()
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                Id = 2,
                Name = "Karan Mandve",
                Designation = "Python Developer"
            });
        }
    }
}
