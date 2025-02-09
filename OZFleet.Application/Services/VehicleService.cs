using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Application.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Task<IEnumerable<Vehicle>> GetAllVehiclesAsync() =>
            _vehicleRepository.GetAllAsync();

        public Task<Vehicle> GetVehicleByIdAsync(int id) =>
            _vehicleRepository.GetByIdAsync(id);

        public Task AddVehicleAsync(Vehicle vehicle) =>
            _vehicleRepository.AddAsync(vehicle);

        public Task UpdateVehicleAsync(Vehicle vehicle) =>
            _vehicleRepository.UpdateAsync(vehicle);

        public Task DeleteVehicleAsync(int id) =>
            _vehicleRepository.DeleteAsync(id);
    }
}
