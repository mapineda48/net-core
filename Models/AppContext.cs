using Microsoft.EntityFrameworkCore;

namespace Climate.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<History> Historys { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<CityData> CityDatas { get; set; }
}
