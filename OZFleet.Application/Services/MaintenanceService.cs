using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Application.Services
{
    public class MaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public Task<IEnumerable<Maintenance>> GetAllMaintenanceAsync() =>
            _maintenanceRepository.GetAllAsync();

        public Task<Maintenance> GetMaintenanceByIdAsync(int id) =>
            _maintenanceRepository.GetByIdAsync(id);

        public Task AddMaintenanceAsync(Maintenance maintenance) =>
            _maintenanceRepository.AddAsync(maintenance);

        public Task UpdateMaintenanceAsync(Maintenance maintenance) =>
            _maintenanceRepository.UpdateAsync(maintenance);

        public Task DeleteMaintenanceAsync(int id) =>
            _maintenanceRepository.DeleteAsync(id);
    }
}
