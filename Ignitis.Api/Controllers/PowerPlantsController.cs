using Ignitis.Services;
using Ignitis.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ignitis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerPlantsController : ControllerBase
    {
        private readonly IPowerPlantService _service;
        public PowerPlantsController(IPowerPlantService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PowerPlantDto>> GetByDate([FromQuery][Required] DateTimeOffset date)
        {
            return await _service.GetByDateAsync(date);
        }
    }
}
