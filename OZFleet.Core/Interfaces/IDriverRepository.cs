using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;

namespace OZFleet.Core.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllAsync();
        Task<Driver> GetByIdAsync(int id);
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        Task DeleteAsync(int id);
    }
}
