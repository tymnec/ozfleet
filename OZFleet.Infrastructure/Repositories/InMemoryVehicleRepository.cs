using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Infrastructure.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new();

        public Task AddAsync(Vehicle vehicle)
        {
            vehicle.Id = _vehicles.Any() ? _vehicles.Max(v => v.Id) + 1 : 1;
            _vehicles.Add(vehicle);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                _vehicles.Remove(vehicle);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Vehicle>> GetAllAsync() =>
            Task.FromResult<IEnumerable<Vehicle>>(_vehicles);

        public Task<Vehicle> GetByIdAsync(int id) =>
            Task.FromResult(_vehicles.FirstOrDefault(v => v.Id == id));

        public Task UpdateAsync(Vehicle vehicle)
        {
            var existing = _vehicles.FirstOrDefault(v => v.Id == vehicle.Id);
            if (existing != null)
            {
                existing.Make = vehicle.Make;
                existing.Model = vehicle.Model;
                existing.Year = vehicle.Year;
            }
            return Task.CompletedTask;
        }
    }
}
