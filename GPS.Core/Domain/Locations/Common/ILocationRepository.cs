using GPS.Core.Domain.Locations.Models;

namespace GPS.Core.Domain.Locations.Common;

public interface ILocationRepository
{
    Task<Location> FindAsync(long id);

    Task AddAsync(Location location);

    Task DeleteAsync(long id);
}