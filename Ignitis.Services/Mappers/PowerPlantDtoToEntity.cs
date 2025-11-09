using Ignitis.Entities;
using Ignitis.Services.Dtos;

namespace Ignitis.Services.Mappers
{
    public static class PowerPlantDtoToEntity
    {
        public static PowerPlant ToEntity(this PowerPlantDto dto)
        {
            return new PowerPlant
            {
                Id = dto.Id,
                Owner = dto.Owner,
                Power = dto.Power!.Value,
                ValidFrom = dto.ValidFrom!.Value,
                ValidTo = dto.ValidTo,
            };
        }
    }
}
