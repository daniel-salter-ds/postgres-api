using Microsoft.AspNetCore.Mvc;
using PostgresApi.Models;
using PostgresApi.Services;

namespace PostgresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController(WeatherForecastService forecastService) : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return forecastService.GetForecasts();
        }
    }
}