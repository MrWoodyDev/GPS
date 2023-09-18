namespace GPS.Application.Domain.Locations.Queries.GetLocationById;

public record LocationByIdDto
{
    public long Id { get; init; }

    public double Latitude { get; init; }

    public double Longitude { get; init; }

    public string Address { get; init; }

    public DateTime CreateTime { get; init; }
}