using Weather.Services.Models;

namespace Weather.Services.Services;

public interface IWeatherParser
{
    /// <summary>
    /// Parse xlsx file from given <paramref name="stream"/>
    /// <para> 
    /// <see cref="InvalidOperationException"/> if file is invalid.
    /// </para>
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    IEnumerable<WeatherData> Parse(Stream stream);
}
