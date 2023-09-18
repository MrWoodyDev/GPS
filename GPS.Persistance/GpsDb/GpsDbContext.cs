using GPS.Core.Domain.Locations.Models;
using GPS.Persistence.GPSDb.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GPS.Persistence.GpsDb;

public class GpsDbContext : IdentityDbContext<AppUser>
{
    public GpsDbContext(DbContextOptions<GpsDbContext> options)
        : base(options)
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
