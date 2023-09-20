using GPS.Core.Common;
using GPS.Core.Domain.Locations.Common;
using GPS.Core.Domain.Locations.Models;
using MediatR;

namespace GPS.Application.Domain.Locations.Commands.CreateLocation;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        var location = await Location.CreateAsync(
            command.Login,
            command.Password,
            command.FirstName,
            command.LastName,
            command.MiddleName,
            command.JobTitle,
            command.Latitude,
            command.Longitude);
        await _locationRepository.AddAsync(location);
        await _unitOfWork.SaveChanges(cancellationToken);
        return Unit.Value;
    }
}