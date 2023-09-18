using MediatR;

namespace GPS.Application.Domain.Locations.Queries.GetLocations;

public record GetLocationQuery() : IRequest<LocationDto[]>;