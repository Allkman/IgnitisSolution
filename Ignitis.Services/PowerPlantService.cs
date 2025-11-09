using Ignitis.Services.Dtos;
using Ignitis.Services.Mappers;
using Ignitis.Storage;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        private readonly StorageContext _context;
        private const int MinOwnerFilterLength = 3;
        public PowerPlantService(StorageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedPowerPlantResponse<PowerPlantDto>> GetPaginatedAsync(PaginatedPowerPlantRequest request)
        {
            var query = _context.PowerPlants.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Owner) && request.Owner.Trim().Length >= MinOwnerFilterLength)
            {
                var normalized = request.Owner.Trim().ToLower();
                query = query.Where(pp => pp.Owner.ToLower().Contains(normalized));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(pp => pp.ValidFrom)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(pp => pp.ToDto())
                .ToListAsync();

            return new PaginatedPowerPlantResponse<PowerPlantDto>
            {
                Items = items,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task CreatePowerPlantAsync(PowerPlantDto dto)
        {
            var entity = dto.ToEntity();

            await _context.PowerPlants.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}