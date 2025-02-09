using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Infrastructure.Repositories
{
    public class InMemoryFuelRecordRepository : IFuelRecordRepository
    {
        private readonly List<FuelRecord> _fuelRecords = new();

        public Task AddAsync(FuelRecord fuelRecord)
        {
            fuelRecord.Id = _fuelRecords.Any() ? _fuelRecords.Max(f => f.Id) + 1 : 1;
            _fuelRecords.Add(fuelRecord);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var fuelRecord = _fuelRecords.FirstOrDefault(f => f.Id == id);
            if (fuelRecord != null)
                _fuelRecords.Remove(fuelRecord);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<FuelRecord>> GetAllAsync() =>
            Task.FromResult<IEnumerable<FuelRecord>>(_fuelRecords);

        public Task<FuelRecord> GetByIdAsync(int id) =>
            Task.FromResult(_fuelRecords.FirstOrDefault(f => f.Id == id));

        public Task UpdateAsync(FuelRecord fuelRecord)
        {
            var existing = _fuelRecords.FirstOrDefault(f => f.Id == fuelRecord.Id);
            if (existing != null)
            {
                existing.VehicleId = fuelRecord.VehicleId;
                existing.DriverId = fuelRecord.DriverId;
                existing.FuelDate = fuelRecord.FuelDate;
                existing.FuelAmount = fuelRecord.FuelAmount;
                existing.Cost = fuelRecord.Cost;
                existing.OdometerReading = fuelRecord.OdometerReading;
            }
            return Task.CompletedTask;
        }
    }
}
