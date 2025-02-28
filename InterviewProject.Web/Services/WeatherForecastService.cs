using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;
    private readonly string _apiKey;
    private readonly ILogger<WeatherForecastService> _logger;

    public WeatherForecastService(HttpClient httpClient, IConfiguration configuration, ILogger<WeatherForecastService> logger)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["WeatherApi:BaseUrl"];
        _apiKey = configuration["WeatherApi:ApiKey"];
        _logger = logger;
    }

    public async Task<WeatherForecastResponse> GetFiveDayForecastAsync(string city)
    {
        try
        {
            var url = $"{_apiUrl}?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Weather API request failed: {StatusCode}", response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherForecastResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (weatherData == null || weatherData.List == null)
                return null;

            var groupedForecasts = weatherData.List
                .Where(item => DateTime.TryParseExact(item.DtTxt, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                .GroupBy(item => item.DtTxt.Split(' ')[0])
                .Select(g => g.First())
                .Take(5)
                .ToList();

            weatherData.List = groupedForecasts;
            return weatherData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching weather data for {City}", city);
            return null;
        }
    }
}
