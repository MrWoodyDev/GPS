﻿namespace GPS.Api.Domain.Locations.Request;


public record CreateLocationRequest(double Latitude, double Longitude, string Address, string UserId);