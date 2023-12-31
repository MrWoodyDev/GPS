﻿using GPS.Core.Domain.Locations.Models;
using GPS.Persistence.GpsDb;
using GPS.Persistence.GPSDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GPS.Persistence;

public static class PersistenceRegistration
{
    private const string ConnectionString = "GpsDb";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString)
                               ?? throw new AggregateException($"Connection string: '{ConnectionString}' is not found in configurations.");

        services.AddDbContext<GpsDbContext>(options =>
            options.UseNpgsql(connectionString), ServiceLifetime.Singleton);

        services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<GpsDbContext>();
    }
}
