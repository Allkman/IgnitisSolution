using Ignitis.Services;
using Ignitis.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ignitis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerPlantsController : ControllerBase
    {
        private readonly IPowerPlantService _powerPlantService;
        public PowerPlantsController(IPowerPlantService powerPlantService)
        {
            _powerPlantService = powerPlantService ?? throw new ArgumentNullException(nameof(powerPlantService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedPowerPlantResponse<PowerPlantDto>>> GetPaginated([FromQuery] PaginatedPowerPlantRequest request)
        {
            return Ok(await _powerPlantService.GetPaginatedAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PowerPlantDto>> CreatePowerPlant([FromBody] PowerPlantDto dto)
        {
            await _powerPlantService.CreatePowerPlantAsync(dto);

            return CreatedAtAction(nameof(CreatePowerPlant), new { id = dto.Id }, dto);
        }
    }
}
