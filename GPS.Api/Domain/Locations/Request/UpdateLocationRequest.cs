namespace GPS.Api.Domain.Locations.Request;

public record UpdateLocationRequest(string UserId, double Latitude, double Longitude, string Address);