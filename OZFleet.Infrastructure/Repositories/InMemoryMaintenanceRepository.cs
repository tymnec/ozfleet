using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Infrastructure.Repositories
{
    public class InMemoryMaintenanceRepository : IMaintenanceRepository
    {
        private readonly List<Maintenance> _maintenances = new();

        public Task AddAsync(Maintenance maintenance)
        {
            maintenance.Id = _maintenances.Any() ? _maintenances.Max(m => m.Id) + 1 : 1;
            _maintenances.Add(maintenance);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var maintenance = _maintenances.FirstOrDefault(m => m.Id == id);
            if (maintenance != null)
                _maintenances.Remove(maintenance);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Maintenance>> GetAllAsync() =>
            Task.FromResult<IEnumerable<Maintenance>>(_maintenances);

        public Task<Maintenance> GetByIdAsync(int id) =>
            Task.FromResult(_maintenances.FirstOrDefault(m => m.Id == id));

        public Task UpdateAsync(Maintenance maintenance)
        {
            var existing = _maintenances.FirstOrDefault(m => m.Id == maintenance.Id);
            if (existing != null)
            {
                existing.VehicleId = maintenance.VehicleId;
                existing.MaintenanceDate = maintenance.MaintenanceDate;
                existing.Description = maintenance.Description;
                existing.Cost = maintenance.Cost;
                existing.NextDueDate = maintenance.NextDueDate;
            }
            return Task.CompletedTask;
        }
    }
}
