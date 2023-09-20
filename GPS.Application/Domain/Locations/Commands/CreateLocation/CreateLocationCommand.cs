using MediatR;

namespace GPS.Application.Domain.Locations.Commands.CreateLocation;

public record CreateLocationCommand(string Login, string Password, string FirstName, string LastName, string MiddleName, string JobTitle, double Latitude, double Longitude) : IRequest<Unit>;