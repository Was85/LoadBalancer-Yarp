using Microsoft.AspNetCore.Mvc;

namespace WebApi_Test.Controllers
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
            string scheme = HttpContext.Request.Scheme;

            // Get the host (includes domain and port)
            var host = HttpContext.Request.Host;

            // Get the path and query string if any
            var path = HttpContext.Request.Path;
            var queryString = HttpContext.Request.QueryString;

            // Construct the full URL
            string completeUrl = $"{scheme}://{host}{path}{queryString}";

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                ResponseFrom = completeUrl
            })
            .ToArray();
        }
    }
}