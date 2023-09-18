using MediatR;

namespace GPS.Application.Domain.Locations.Commands.RemoveLocation;

public record RemoveLocationCommand(long Id) : IRequest<Unit>;