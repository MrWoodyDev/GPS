using GPS.Core.Domain.Locations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPS.Persistence.GPSDb.EntityConfigurations;

public class LocationEntityConfigurations : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => new {x.Login, x.Password});
    }
}