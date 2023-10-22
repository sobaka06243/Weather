using Weather.Services.Models;
using Weather.Services.Services;

namespace Weather.XLSX_Reader.Services;

public class WeatherParser : IWeatherParser
{
    public Task<IEnumerable<WeatherData>> Parse(Stream stream)
    {
        throw new NotImplementedException();
    }
}
