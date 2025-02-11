using Microsoft.OpenApi.Models;
using OZFleet.Application.Services;
using OZFleet.Core.Interfaces;
using OZFleet.Infrastructure.Repositories;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add controllers
        builder.Services.AddControllers();

        // Add CORS services with a specific policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp", policy =>
            {
                policy.WithOrigins("http://localhost:3000") // React app URL
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        // Configure Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OZFleet API", Version = "v1" });
        });

        // Register existing repositories and services
        builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
        builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        builder.Services.AddTransient<VehicleService>();
        builder.Services.AddTransient<UserService>();

        // Register new repositories
        builder.Services.AddSingleton<ITripRepository, InMemoryTripRepository>();
        builder.Services.AddSingleton<IMaintenanceRepository, InMemoryMaintenanceRepository>();
        builder.Services.AddSingleton<IFuelRecordRepository, InMemoryFuelRecordRepository>();
        builder.Services.AddSingleton<IDriverRepository, InMemoryDriverRepository>();

        // Register new services
        builder.Services.AddTransient<TripService>();
        builder.Services.AddTransient<MaintenanceService>();
        builder.Services.AddTransient<FuelRecordService>();
        builder.Services.AddTransient<DriverService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OZFleet API v1");
            });
        }

        // Enable CORS using the defined policy
        app.UseCors("AllowReactApp");

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}