using System.Threading.Tasks;

public interface IWeatherForecastService
{
    Task<WeatherForecastResponse> GetFiveDayForecastAsync(string city);
}