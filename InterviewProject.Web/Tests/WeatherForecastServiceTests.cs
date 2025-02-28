using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Xunit;

public class WeatherForecastServiceTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly Mock<ILogger<WeatherForecastService>> _loggerMock;
    private readonly WeatherForecastService _service;

    public WeatherForecastServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://api.openweathermap.org/")
        };

        _configurationMock = new Mock<IConfiguration>();
        _configurationMock.Setup(c => c["WeatherApi:BaseUrl"]).Returns("https://api.openweathermap.org/data/2.5/forecast");
        _configurationMock.Setup(c => c["WeatherApi:ApiKey"]).Returns("dded647cd61239fbdbea35c7af2aecd7");

        _loggerMock = new Mock<ILogger<WeatherForecastService>>();

        _service = new WeatherForecastService(_httpClient, _configurationMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetFiveDayForecastAsync_ValidCity_ReturnsWeatherData()
    {
        // Arrange
        var jsonResponse = @"
        {
            ""list"": [
                {
                    ""dt_txt"": ""2024-03-01 12:00:00"",
                    ""main"": { ""temp"": 22.5 }
                },
                {
                    ""dt_txt"": ""invalid-date"",
                    ""main"": { ""temp"": 25.0 }
                }
            ]
        }";

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse)
            });

        // Act
        var result = await _service.GetFiveDayForecastAsync("Lima");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.List);
        Assert.Equal(22.5, result.List[0].Main.Temp);
    }

    [Fact]
    public async Task GetFiveDayForecastAsync_ApiError_ReturnsNull()
    {
        // Arrange
        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            });

        // Act
        var result = await _service.GetFiveDayForecastAsync("Lima");

        // Assert
        Assert.Null(result);
    }
}
