using MediatR;

namespace GPS.Application.Domain.Locations.Commands.UpdateLocation;

public record UpdateLocationCommand(long Id, double Latitude, double Longitude) : IRequest<Unit>;