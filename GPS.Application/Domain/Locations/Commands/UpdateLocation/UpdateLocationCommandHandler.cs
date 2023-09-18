using GPS.Core.Common;
using GPS.Core.Domain.Locations.Common;
using GPS.Core.Domain.Locations.Data;
using MediatR;

namespace GPS.Application.Domain.Locations.Commands.UpdateLocation;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Unit>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
    {
        var original = await _locationRepository.FindAsync(command.UserId);
        var data = new UpdateLocationData(command.Latitude, command.Longitude, command.Address, command.UserId);
        await original.UpdateAsync(data, cancellationToken);
        await _unitOfWork.SaveChanges(cancellationToken);
        return Unit.Value;
    }
}