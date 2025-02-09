using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Infrastructure.Repositories
{
    public class InMemoryTripRepository : ITripRepository
    {
        private readonly List<Trip> _trips = new();

        public Task AddAsync(Trip trip)
        {
            trip.Id = _trips.Any() ? _trips.Max(t => t.Id) + 1 : 1;
            _trips.Add(trip);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var trip = _trips.FirstOrDefault(t => t.Id == id);
            if (trip != null)
                _trips.Remove(trip);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Trip>> GetAllAsync() =>
            Task.FromResult<IEnumerable<Trip>>(_trips);

        public Task<Trip> GetByIdAsync(int id) =>
            Task.FromResult(_trips.FirstOrDefault(t => t.Id == id));

        public Task UpdateAsync(Trip trip)
        {
            var existing = _trips.FirstOrDefault(t => t.Id == trip.Id);
            if (existing != null)
            {
                existing.VehicleId = trip.VehicleId;
                existing.DriverId = trip.DriverId;
                existing.StartTime = trip.StartTime;
                existing.EndTime = trip.EndTime;
                existing.StartLocation = trip.StartLocation;
                existing.EndLocation = trip.EndLocation;
                existing.Distance = trip.Distance;
            }
            return Task.CompletedTask;
        }
    }
}
