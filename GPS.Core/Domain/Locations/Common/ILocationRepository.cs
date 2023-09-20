using GPS.Core.Domain.Locations.Models;

namespace GPS.Core.Domain.Locations.Common;

public interface ILocationRepository
{
    Task<Location> FindAsync(string login, string password);

    Task AddAsync(Location location);

    Task DeleteAsync(string login, string password);
}