using GPS.Web.Clients;
using Microsoft.AspNetCore.Mvc;

namespace GPS.Web.Controllers;

public class LocationController : Controller
{
    private readonly IGpsClient _client;

    public LocationController(IGpsClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await _client.GetLocationsAsync(cancellationToken));
    }
}