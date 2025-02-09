using Microsoft.AspNetCore.Mvc;
using OZFleet.Application.Services;
using OZFleet.Core.Entities;
using System.Threading.Tasks;

namespace OZFleet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _tripService.GetAllTripsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await _tripService.GetTripByIdAsync(id);
            if (trip == null)
                return NotFound();
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Trip trip)
        {
            await _tripService.AddTripAsync(trip);
            return CreatedAtAction(nameof(Get), new { id = trip.Id }, trip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Trip trip)
        {
            if (id != trip.Id)
                return BadRequest("ID mismatch");
            await _tripService.UpdateTripAsync(trip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tripService.DeleteTripAsync(id);
            return NoContent();
        }
    }
}
