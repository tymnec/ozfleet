using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private readonly List<Driver> _drivers = new();

        public Task AddAsync(Driver driver)
        {
            driver.Id = _drivers.Any() ? _drivers.Max(d => d.Id) + 1 : 1;
            _drivers.Add(driver);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
                _drivers.Remove(driver);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Driver>> GetAllAsync() =>
            Task.FromResult<IEnumerable<Driver>>(_drivers);

        public Task<Driver> GetByIdAsync(int id) =>
            Task.FromResult(_drivers.FirstOrDefault(d => d.Id == id));

        public Task UpdateAsync(Driver driver)
        {
            var existing = _drivers.FirstOrDefault(d => d.Id == driver.Id);
            if (existing != null)
            {
                existing.Name = driver.Name;
                existing.LicenseNumber = driver.LicenseNumber;
                existing.LicenseExpiry = driver.LicenseExpiry;
            }
            return Task.CompletedTask;
        }
    }
}
