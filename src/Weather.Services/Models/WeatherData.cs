using System.Drawing;

namespace Weather.Services.Models;

public class WeatherData
{
    public WeatherData(
        DateOnly date, 
        TimeOnly time, 
        float temperature, 
        int relativeHumidity, 
        float dewPoint, 
        int atmospherePressure,
        string windDirection,
        int windSpeed,
        int? cloudiness,
        int cloudBase,
        int? horizontalVisibility,
        string? weatherConditions)
    {
        Date = date;
        Time = time;
        Temperature = temperature;
        RelativeHumidity = relativeHumidity;
        DewPoint = dewPoint;
        AtmospherePressure = atmospherePressure;
        WindDirection = windDirection;
        WindSpeed = windSpeed;
        Cloudiness = cloudiness;
        CloudBase = cloudBase;
        HorizontalVisibility = horizontalVisibility;
        WeatherConditions = weatherConditions;
    }

    public DateOnly Date { get; }

    public TimeOnly Time { get; }

    public float Temperature { get; }

    public int RelativeHumidity { get; }

    public float DewPoint { get; }

    public int AtmospherePressure { get; }

    public string WindDirection { get; }

    public int WindSpeed { get; }

    public int? Cloudiness { get; }

    public int CloudBase { get; }

    public int? HorizontalVisibility { get; }

    public string? WeatherConditions { get; }

}
