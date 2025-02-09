using Microsoft.AspNetCore.Mvc;
using OZFleet.Application.Services;
using OZFleet.Core.Entities;
using System.Threading.Tasks;

namespace OZFleet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _driverService.GetAllDriversAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
                return NotFound();
            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Driver driver)
        {
            await _driverService.AddDriverAsync(driver);
            return CreatedAtAction(nameof(Get), new { id = driver.Id }, driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Driver driver)
        {
            if (id != driver.Id)
                return BadRequest("ID mismatch");
            await _driverService.UpdateDriverAsync(driver);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _driverService.DeleteDriverAsync(id);
            return NoContent();
        }
    }
}
