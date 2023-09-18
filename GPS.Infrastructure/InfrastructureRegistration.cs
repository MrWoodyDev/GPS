using GPS.Core.Common;
using GPS.Core.Domain.Locations.Common;
using GPS.Infrastructure.Core.Common;
using GPS.Infrastructure.Core.Domain.Locations.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GPS.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureRegistration(this IServiceCollection service)
    {
        service.AddMediatR(typeof(InfrastructureRegistration));

        //UnitOfWork
        service.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repository
        service.AddScoped<ILocationRepository, LocationRepository>();
    }
}