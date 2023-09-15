namespace GPS.Application.Domain.Locations.Queries.GetLocations;

public record LocationDto
{
    public long Id { get; init; }

    public double Latitude { get; init; }

    public double Longitude { get; init; }

    public DateTime CreateTime { get; init; }
}