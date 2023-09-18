using MediatR;

namespace GPS.Application.Domain.Locations.Commands.UpdateLocation;

public record UpdateLocationCommand(double Latitude, double Longitude, string Address, string UserId) : IRequest<Unit>;