using GPS.Core.Common;
using GPS.Core.Domain.Locations.Common;
using GPS.Core.Domain.Locations.Models;
using MediatR;

namespace GPS.Application.Domain.Locations.Commands.CreateLocation;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, long>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        var location = await Location.CreateAsync(command.Latitude, command.Longitude, command.Address, command.UserId);
        await _locationRepository.AddAsync(location);
        await _unitOfWork.SaveChanges(cancellationToken);
        return location.Id;
    }
}