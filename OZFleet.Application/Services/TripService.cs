using System.Collections.Generic;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Application.Services
{
    public class TripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public Task<IEnumerable<Trip>> GetAllTripsAsync() =>
            _tripRepository.GetAllAsync();

        public Task<Trip> GetTripByIdAsync(int id) =>
            _tripRepository.GetByIdAsync(id);

        public Task AddTripAsync(Trip trip) =>
            _tripRepository.AddAsync(trip);

        public Task UpdateTripAsync(Trip trip) =>
            _tripRepository.UpdateAsync(trip);

        public Task DeleteTripAsync(int id) =>
            _tripRepository.DeleteAsync(id);
    }
}
