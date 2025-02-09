using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;

namespace OZFleet.Core.Interfaces
{
    public interface IFuelRecordRepository
    {
        Task<IEnumerable<FuelRecord>> GetAllAsync();
        Task<FuelRecord> GetByIdAsync(int id);
        Task AddAsync(FuelRecord fuelRecord);
        Task UpdateAsync(FuelRecord fuelRecord);
        Task DeleteAsync(int id);
    }
}
