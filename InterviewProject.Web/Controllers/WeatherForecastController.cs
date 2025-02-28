using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherService;

    public WeatherForecastController(IWeatherForecastService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetForecast(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest("City is required");

        var forecast = await _weatherService.GetFiveDayForecastAsync(city);
        return Ok(forecast);
    }
}
