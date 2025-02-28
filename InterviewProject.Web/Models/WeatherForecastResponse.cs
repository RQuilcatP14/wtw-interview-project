using System.Collections.Generic;
using System.Text.Json.Serialization;

public class WeatherForecastResponse
{
    [JsonPropertyName("list")]
    public List<WeatherItem> List { get; set; }
}

public class WeatherItem
{
    [JsonPropertyName("dt_txt")]
    public string DtTxt { get; set; }

    [JsonPropertyName("main")]
    public TemperatureInfo Main { get; set; }
}

public class TemperatureInfo
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }
}
