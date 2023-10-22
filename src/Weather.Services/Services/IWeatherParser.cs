using Weather.Services.Models;

namespace Weather.Services.Services;

public interface IWeatherParser
{
    IEnumerable<WeatherData> Parse(Stream stream);
}
