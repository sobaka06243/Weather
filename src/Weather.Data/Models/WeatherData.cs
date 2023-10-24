using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Weather.Data.Models;

internal class WeatherData
{
    [Key]
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public float Temperature { get; set; }

    public int RelativeHumidity { get; set; }

    public float DewPoint { get; set; }

    public int AtmospherePressure { get; set; }

    public string? WindDirection { get; set; }

    public int? WindSpeed { get; set; }

    public int? Cloudiness { get; set; }

    public int? CloudBase { get; set; }

    public int? HorizontalVisibility { get; set; }

    public string? WeatherConditions { get; set; }
}

internal class WeatherDataConfiguration : IEntityTypeConfiguration<WeatherData>
{
    public void Configure(EntityTypeBuilder<WeatherData> builder)
    {
        builder.ToTable("Weather");

        builder.HasKey(e => e.Id);

        builder.HasIndex(e => new { e.Date, e.Time }).IsUnique(true);
    }
}
