using System.Security.Claims;
using GPS.Application.Domain.Locations.Commands.CreateLocation;
using GPS.Application.Domain.Locations.Commands.UpdateLocation;
using GPS.Application.Domain.Locations.Queries.GetLocations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<RedirectToActionResult> Create(double latitude, double longitude, string address)
    {
        var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var command = new CreateLocationCommand(latitude, longitude, address, id);
        await _mediator.Send(command);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<RedirectToActionResult> Edit(double latitude, double longitude, string address)
    {
        var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var command = new UpdateLocationCommand(latitude, longitude, address, id);
        await _mediator.Send(command);
        return RedirectToAction("Index");
    }
}