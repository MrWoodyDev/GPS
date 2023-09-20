using MediatR;

namespace GPS.Application.Domain.Locations.Commands.RemoveLocation;

public record RemoveLocationCommand(string Login, string Passwod) : IRequest<Unit>;