using Microsoft.AspNetCore.Mvc;
using OZFleet.Application.Services;
using OZFleet.Core.Entities;
using System.Threading.Tasks;

namespace OZFleet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly MaintenanceService _maintenanceService;

        public MaintenanceController(MaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _maintenanceService.GetAllMaintenanceAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var maintenance = await _maintenanceService.GetMaintenanceByIdAsync(id);
            if (maintenance == null)
                return NotFound();
            return Ok(maintenance);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Maintenance maintenance)
        {
            await _maintenanceService.AddMaintenanceAsync(maintenance);
            return CreatedAtAction(nameof(Get), new { id = maintenance.Id }, maintenance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Maintenance maintenance)
        {
            if (id != maintenance.Id)
                return BadRequest("ID mismatch");
            await _maintenanceService.UpdateMaintenanceAsync(maintenance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _maintenanceService.DeleteMaintenanceAsync(id);
            return NoContent();
        }
    }
}
