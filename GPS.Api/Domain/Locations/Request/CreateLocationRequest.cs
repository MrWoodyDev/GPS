namespace GPS.Api.Domain.Locations.Request;


public record CreateLocationRequest(string Login, string Password, string FirstName, string LastName, string MiddleName, string JobTitle, double Latitude, double Longitude);