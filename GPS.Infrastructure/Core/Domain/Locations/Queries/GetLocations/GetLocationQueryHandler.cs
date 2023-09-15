using GPS.Application.Domain.Locations.Queries.GetLocations;
using GPS.Persistence.GPSDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPS.Infrastructure.Core.Domain.Locations.Queries.GetLocations;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, LocationDto[]>
{
    private readonly GpsDbContext _dbContext;

    public GetLocationQueryHandler(GpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LocationDto[]> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _dbContext.Locations.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(location => location.Id)
            .Select(location => new LocationDto
            {
                Id = location.Id,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CreateTime = location.CreateTime
            })
            .ToArrayAsync(cancellationToken);
        return data;
    }
}