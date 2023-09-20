using MediatR;

namespace GPS.Application.Domain.Locations.Commands.UpdateLocation;

public record UpdateLocationCommand(string Login, string Password, double Latitude, double Longitude) : IRequest<Unit>;