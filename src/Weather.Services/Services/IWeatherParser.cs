using Weather.Services.Models;

namespace Weather.Services.Services;

public interface IWeatherParser
{
    Task<IEnumerable<WeatherData>> Parse(Stream stream);
}
