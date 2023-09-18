using Microsoft.AspNetCore.Identity;

namespace GPS.Core.Domain.Locations.Models;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MeddleName { get; set; }

    public string? JobTitle {get; set; }
}

