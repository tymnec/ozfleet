using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;

namespace OZFleet.Core.Interfaces
{
    public interface IMaintenanceRepository
    {
        Task<IEnumerable<Maintenance>> GetAllAsync();
        Task<Maintenance> GetByIdAsync(int id);
        Task AddAsync(Maintenance maintenance);
        Task UpdateAsync(Maintenance maintenance);
        Task DeleteAsync(int id);
    }
}
