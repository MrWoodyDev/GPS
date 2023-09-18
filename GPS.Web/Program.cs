using GPS.Application;
using GPS.Core.Domain.Locations.Models;
using GPS.Infrastructure;
using GPS.Persistence;
using GPS.Persistence.GpsDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GpsDb") ?? throw new InvalidOperationException("Connection string 'GPSWebContextConnection' not found.");

builder.Services.AddDbContext<GpsDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GpsDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructureRegistration();
builder.Services.AddApplicationRegistration();
//builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
