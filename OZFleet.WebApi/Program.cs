using Microsoft.OpenApi.Models;
using OZFleet.Application.Services;
using OZFleet.Core.Interfaces;
using OZFleet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OZFleet API", Version = "v1" });
});

// Register repository implementations as singletons (for in-memory demo)
builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();

// Register application services
builder.Services.AddTransient<VehicleService>();
builder.Services.AddTransient<UserService>();

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OZFleet API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
