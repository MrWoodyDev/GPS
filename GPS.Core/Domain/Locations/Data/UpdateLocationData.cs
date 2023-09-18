namespace GPS.Core.Domain.Locations.Data;

public record UpdateLocationData(double Latitude, double Longitude, string Address, string UserId);