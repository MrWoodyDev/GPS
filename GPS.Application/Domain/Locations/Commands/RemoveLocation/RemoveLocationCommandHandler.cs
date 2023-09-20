using GPS.Core.Common;
using GPS.Core.Domain.Locations.Common;
using MediatR;

namespace GPS.Application.Domain.Locations.Commands.RemoveLocation;

public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand, Unit>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveLocationCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveLocationCommand command, CancellationToken cancellationToken)
    {
        await _locationRepository.DeleteAsync(command.Login, command.Passwod);
        await _unitOfWork.SaveChanges(cancellationToken);
        return Unit.Value;
    }
}