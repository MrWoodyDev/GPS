using GPS.Api.Common;
using GPS.Api.Domain.Locations.Request;
using GPS.Application.Domain.Locations.Commands.CreateLocation;
using GPS.Application.Domain.Locations.Commands.RemoveLocation;
using GPS.Application.Domain.Locations.Commands.UpdateLocation;
using GPS.Application.Domain.Locations.Queries.GetLocationById;
using GPS.Application.Domain.Locations.Queries.GetLocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPS.Api.Domain.Locations;

[ApiController]
[Route(Routs.Locations)]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<LocationDto[]> GetLocationsAsync(CancellationToken cancellationToken)
    {
        var query = new GetLocationQuery();
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<LocationByIdDto> GetLocationByIdAsync(long id ,CancellationToken cancellationToken)
    {
        var query = new GetLocationByIdQuery(id);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    public async Task<long> PostLocationAsync([FromBody] CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(request.Latitude, request.Longitude);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut]
    public async Task PutLocationAsync([FromBody] UpdateLocationRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateLocationCommand(request.Id, request.Latitude, request.Longitude);
        await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteLocationAsync([FromBody] RemoveLocationRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveLocationCommand(request.Id);
        await _mediator.Send(command, cancellationToken);
    }
}