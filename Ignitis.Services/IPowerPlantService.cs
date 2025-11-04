using Ignitis.Services.Dtos;

namespace Ignitis.Services
{
    public interface IPowerPlantService
    {
        Task<IEnumerable<PowerPlantDto>> GetByDateAsync(DateTimeOffset date);
    }
}
