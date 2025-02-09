using System;
using System.Collections.Generic;

namespace OZFleet.Application.Services
{
    public class FleetAssignmentService
    {
        private readonly List<Vehicle> _vehicles;
        private readonly List<Driver> _drivers;

        // Constructor to initialize with lists of vehicles and drivers
        public FleetAssignmentService(List<Vehicle> vehicles, List<Driver> drivers)
        {
            _vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles), "Vehicles cannot be null.");
            _drivers = drivers ?? throw new ArgumentNullException(nameof(drivers), "Drivers cannot be null.");
        }

        // Method to assign a driver to a vehicle
        public void AssignDriverToVehicle(int vehicleId, int driverId)
        {
            var vehicle = _vehicles.Find(v => v.VehicleId == vehicleId);
            var driver = _drivers.Find(d => d.DriverId == driverId);

            if (vehicle == null)
            {
                throw new ArgumentException("Vehicle not found.");
            }

            if (driver == null)
            {
                throw new ArgumentException("Driver not found.");
            }

            // Assign the driver to the vehicle
            vehicle.AssignDriver(driver);

            Console.WriteLine($"Driver {driver.Name} has been successfully assigned to vehicle {vehicle.Model}.");
        }

        // Method to unassign a driver from a vehicle
        public void UnassignDriverFromVehicle(int vehicleId)
        {
            var vehicle = _vehicles.Find(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                throw new ArgumentException("Vehicle not found.");
            }

            // Unassign the driver
            vehicle.UnassignDriver();

            Console.WriteLine($"Driver has been unassigned from vehicle {vehicle.Model}.");
        }

        // You can add other methods for fleet management if needed
    }
}
