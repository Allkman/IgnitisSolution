using Ignitis.Services.Dtos;

namespace Ignitis.Services
{
    public interface IPowerPlantService
    {
        Task CreatePowerPlantAsync(PowerPlantDto dto);
        Task<PaginatedPowerPlantResponse<PowerPlantDto>> GetPaginatedAsync(PaginatedPowerPlantRequest request);
    }
}
