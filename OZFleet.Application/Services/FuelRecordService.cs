using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Application.Services
{
    public class FuelRecordService
    {
        private readonly IFuelRecordRepository _fuelRecordRepository;

        public FuelRecordService(IFuelRecordRepository fuelRecordRepository)
        {
            _fuelRecordRepository = fuelRecordRepository;
        }

        public Task<IEnumerable<FuelRecord>> GetAllFuelRecordsAsync() =>
            _fuelRecordRepository.GetAllAsync();

        public Task<FuelRecord> GetFuelRecordByIdAsync(int id) =>
            _fuelRecordRepository.GetByIdAsync(id);

        public Task AddFuelRecordAsync(FuelRecord fuelRecord) =>
            _fuelRecordRepository.AddAsync(fuelRecord);

        public Task UpdateFuelRecordAsync(FuelRecord fuelRecord) =>
            _fuelRecordRepository.UpdateAsync(fuelRecord);

        public Task DeleteFuelRecordAsync(int id) =>
            _fuelRecordRepository.DeleteAsync(id);
    }
}
