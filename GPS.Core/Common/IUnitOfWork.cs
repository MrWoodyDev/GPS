namespace GPS.Core.Common;

public interface IUnitOfWork
{
    Task SaveChanges(CancellationToken cancellationToken);
}