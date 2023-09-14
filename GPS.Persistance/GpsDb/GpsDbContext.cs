using GPS.Core.Domain.Locations.Models;
using GPS.Persistence.GPSDb.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GPS.Persistence.GPSDb;

public class GpsDbContext : DbContext
{
    public GpsDbContext(DbContextOptions<GpsDbContext> options) : base(options)
    {
        
    }

    public DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new LocationEntityConfigurations());
    }
}