using GPS.Core.Common;
using GPS.Persistence.GPSDb;

namespace GPS.Infrastructure.Core.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly GpsDbContext _dbContext;

    public UnitOfWork(GpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}