using MediatR;

namespace GPS.Application.Domain.Locations.Queries.GetLocationById;

public record GetLocationByIdQuery(long Id) : IRequest<LocationByIdDto>;