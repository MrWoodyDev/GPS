using GPS.Core.Domain.Locations.Data;
using Microsoft.VisualBasic;

namespace GPS.Core.Domain.Locations.Models;

public class Location
{

    private Location()
    {

    }

    public Location(
        string login, 
        string password, 
        string firstName, 
        string lastName, 
        string middleName, 
        string jobTitle,
        double latitude, 
        double longitude,
        DateTime createTime)
    {
        Login = login;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        JobTitle = jobTitle;
        Latitude = latitude;
        Longitude = longitude;
        CreateTime = createTime;
    }

    public string Login { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string JobTitle { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get;  set;}

    public DateTime CreateTime { get; set; }


    public static async Task<Location> CreateAsync(
        string login,
        string password,
        string firstName,
        string lastName,
        string middleName,
        string jobTitle,
        double latitude,
        double longitude)
    {
        var location = new Location(login, password, firstName, lastName, middleName, jobTitle, latitude, longitude, DateTime.UtcNow);
        return location;
    }

    public async Task UpdateAsync(UpdateLocationData data, CancellationToken cancellationToken)
    {
        Latitude = data.Latitude;
        Longitude = data.Longitude;
        CreateTime = DateTime.UtcNow;
    }
}