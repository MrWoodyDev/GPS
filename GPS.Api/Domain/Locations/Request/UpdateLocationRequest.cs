namespace GPS.Api.Domain.Locations.Request;

public record UpdateLocationRequest(string Login, string Password, double Latitude, double Longitude);