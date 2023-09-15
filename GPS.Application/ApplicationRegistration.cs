﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GPS.Application;

public static class ApplicationRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationRegistration));
    }
}