using MediatR;

namespace GPS.Application.Domain.Locations.Commands.CreateLocation;

public record CreateLocationCommand(double Latitude, double Longitude, string Address, string UserId) : IRequest<long>;
