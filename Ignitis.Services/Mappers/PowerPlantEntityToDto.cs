using Ignitis.Entities;
using Ignitis.Services.Dtos;

namespace Ignitis.Services.Mappers
{
    public static class PowerPlantEntityToDto
    {
        public static PowerPlantDto ToDto(this PowerPlant entity)
        {
            return new PowerPlantDto
            {
                Id = entity.Id,
                Owner = entity.Owner,
                Power = entity.Power,
                ValidFrom = entity.ValidFrom,
                ValidTo = entity.ValidTo,
            };
        }
    }
}
