using GPS.Core.Domain.Locations.Data;

namespace GPS.Core.Domain.Locations.Models;

public class Location
{
    private Location()
    {
        
    }

    public Location(double latitude, double longitude, DateTime createTime)
    {
        Latitude = latitude;
        Longitude = longitude;
        CreateTime = createTime;
    }

    public long Id { get; private set; }

    public double Latitude { get; set; }

    public double Longitude { get;  set;}

    public DateTime CreateTime { get; set; }

    public async Task<Location> CreateAsync(double latitude, double longitude)
    {
        var location = new Location(latitude, longitude, DateTime.UtcNow);
        return location;
    }

    public async Task UpdateAsync(UpdateLocationData data)
    {
        Latitude = data.Latitude;
        Longitude = data.Longitude;
        CreateTime = DateTime.UtcNow;
    }
}