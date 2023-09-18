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

    public async Task<Location> FindAsync(string userId)
    {
        var location = await _dbContext.Locations.SingleOrDefaultAsync(x => x.UserId == userId);
        return location ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Location location)
    {
        await _dbContext.AddAsync(location);
    }

    public async Task UpdateAsync(double latitude, double longitude, string address, string userId)
    {
        _dbContext.Database.BeginTransaction();
        try
        {
            var location = _dbContext.Locations.FirstOrDefault(x => x.UserId == userId);
            if (location is null)
            {
                location = new Location(latitude, longitude, address, userId, DateTime.UtcNow);
                _dbContext.Locations.Add(location);
            }
            else
            {
                location.Latitude = latitude;
                location.Longitude = longitude;
                location.Address = address;
            }
            await _dbContext.SaveChangesAsync();
            _dbContext.Database.CommitTransaction();
        }
        catch
        {
            _dbContext.Database.RollbackTransaction();
        }
    }

    public async Task DeleteAsync(long id)
    {
        var locationToBeRemoved = await _dbContext.Locations.SingleOrDefaultAsync(x => x.Id == id);
        if(locationToBeRemoved is null) throw new InvalidOperationException();
        _dbContext.Locations.Remove(locationToBeRemoved);
    }
}