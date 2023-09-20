using GPS.Core.Domain.Locations.Common;
using GPS.Core.Domain.Locations.Models;
using GPS.Persistence.GpsDb;
using GPS.Persistence.GPSDb;
using Microsoft.EntityFrameworkCore;

namespace GPS.Infrastructure.Core.Domain.Locations.Common;

public class LocationRepository : ILocationRepository
{
    private readonly GpsDbContext _dbContext;

    public LocationRepository(GpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Location> FindAsync(string login, string password)
    {
        var location = await _dbContext.Locations.SingleOrDefaultAsync(x => x.Login == login && x.Password == password);
        return location ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Location location)
    {
        await _dbContext.AddAsync(location);
    }

    public async Task DeleteAsync(string login, string password)
    {
        var locationToBeRemoved = await _dbContext.Locations.SingleOrDefaultAsync(x => x.Login == login && x.Password == password);
        if(locationToBeRemoved is null) throw new InvalidOperationException();
        _dbContext.Locations.Remove(locationToBeRemoved);
    }
}