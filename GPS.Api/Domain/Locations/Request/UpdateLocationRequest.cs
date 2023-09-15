namespace GPS.Api.Domain.Locations.Request;

public record UpdateLocationRequest(long Id, double Latitude, double Longitude);