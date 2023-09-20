namespace GPS.Application.Domain.Locations.Queries.GetLocations;

public record LocationDto
{
    public string Login { get; init; }

    public string Password { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string MiddleName { get; init; }

    public string JobTitle { get; init; }

    public double Latitude { get; init; }

    public double Longitude { get; init; }

    public DateTime CreateTime { get; init; }
}