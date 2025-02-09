using Microsoft.AspNetCore.Mvc;
using OZFleet.Application.Services;
using OZFleet.Core.Entities;
using System.Threading.Tasks;

namespace OZFleet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuelRecordController : ControllerBase
    {
        private readonly FuelRecordService _fuelRecordService;

        public FuelRecordController(FuelRecordService fuelRecordService)
        {
            _fuelRecordService = fuelRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _fuelRecordService.GetAllFuelRecordsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var fuelRecord = await _fuelRecordService.GetFuelRecordByIdAsync(id);
            if (fuelRecord == null)
                return NotFound();
            return Ok(fuelRecord);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuelRecord fuelRecord)
        {
            await _fuelRecordService.AddFuelRecordAsync(fuelRecord);
            return CreatedAtAction(nameof(Get), new { id = fuelRecord.Id }, fuelRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FuelRecord fuelRecord)
        {
            if (id != fuelRecord.Id)
                return BadRequest("ID mismatch");
            await _fuelRecordService.UpdateFuelRecordAsync(fuelRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fuelRecordService.DeleteFuelRecordAsync(id);
            return NoContent();
        }
    }
}
