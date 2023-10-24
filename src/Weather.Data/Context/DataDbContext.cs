using Microsoft.EntityFrameworkCore;
using Weather.Data.Models;

namespace Weather.Data.Context;

public class DataDbContext : DbContext
{

    public DataDbContext(DbContextOptions options) : base(options)
    {

    }

    internal virtual DbSet<WeatherData> Weather { get; set; } = null!;
}
