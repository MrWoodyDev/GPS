using GPS.Application.Domain.Locations.Queries.GetLocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPS.Web.Controllers;

public class LocationController : Controller
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ViewResult> Index(CancellationToken cancellationToken)
    {
        var query = new GetLocationQuery();
        return View(await _mediator.Send(query,cancellationToken));
    }
}