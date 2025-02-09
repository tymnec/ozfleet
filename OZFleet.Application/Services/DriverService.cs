using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Application.Services
{
    public class DriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public Task<IEnumerable<Driver>> GetAllDriversAsync() =>
            _driverRepository.GetAllAsync();

        public Task<Driver> GetDriverByIdAsync(int id) =>
            _driverRepository.GetByIdAsync(id);

        public Task AddDriverAsync(Driver driver) =>
            _driverRepository.AddAsync(driver);

        public Task UpdateDriverAsync(Driver driver) =>
            _driverRepository.UpdateAsync(driver);

        public Task DeleteDriverAsync(int id) =>
            _driverRepository.DeleteAsync(id);
    }
}
