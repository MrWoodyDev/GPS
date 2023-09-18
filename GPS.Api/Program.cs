using GPS.Application;
using GPS.Infrastructure;
using GPS.Persistence;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.CustomSchemaIds(type => type.ToString());

    options.CustomOperationIds(apiDescription =>
        apiDescription.TryGetMethodInfo(out var methodInfo)
            ? methodInfo.Name
            : null);
});
builder.Services.AddInfrastructureRegistration();
builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DisplayOperationId());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
