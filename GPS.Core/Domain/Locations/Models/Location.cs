using GPS.Core.Domain.Locations.Data;

namespace GPS.Core.Domain.Locations.Models;

public class Location
{
    private Location()
    {
        
    }

    public Location(double latitude, double longitude, string address, string userId, DateTime createTime)
    {
        Latitude = latitude;
        Longitude = longitude;
        CreateTime = createTime;
        Address = address;
        UserId = userId;
    }

    public long Id { get; private set; }

    public double Latitude { get; set; }

    public double Longitude { get;  set;}

    public string Address { get; set; }

    public DateTime CreateTime { get; set; }

    public string? UserId { get; set; }

    public static async Task<Location> CreateAsync(double latitude, double longitude, string address, string userId)
    {
        var location = new Location(latitude, longitude, address, userId, DateTime.UtcNow);
        return location;
    }

    public async Task UpdateAsync(UpdateLocationData data, CancellationToken cancellationToken)
    {
        Latitude = data.Latitude;
        Longitude = data.Longitude;
        Address = data.Address;
        UserId = data.UserId;
        CreateTime = DateTime.UtcNow;
    }
}