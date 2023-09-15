using GPS.Application.Domain.Locations.Queries.GetLocationById;
using GPS.Persistence.GPSDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPS.Infrastructure.Core.Domain.Locations.Queries.GetLocationById;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationByIdDto>
{
    private readonly GpsDbContext _dbContext;

    public GetLocationByIdQueryHandler(GpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LocationByIdDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _dbContext.Locations.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(location => location.Id)
            .Select(location => new LocationByIdDto
            {
                Id = location.Id,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CreateTime = location.CreateTime
            })
            .FirstOrDefaultAsync(location => location.Id == request.Id, cancellationToken);
        return data;
    }
}