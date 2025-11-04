using Ignitis.Services.Dtos;
using Ignitis.Services.Mappers;
using Ignitis.Storage;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        private readonly StorageContext _context;
        public PowerPlantService(StorageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PowerPlantDto>> GetByDateAsync(DateTimeOffset date)
        {
            return await _context.PowerPlants
                                        .Where(pp => pp.ValidFrom >= date)
                                        .Select(pp => pp.ToDto())
                                        .ToListAsync();
        }
    }
}
