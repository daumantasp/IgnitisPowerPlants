using IgnitisPowerPlants.Application.Dtos;
using IgnitisPowerPlants.Domain.Entities;

namespace IgnitisPowerPlants.Application.Mapper
{
    internal static class PowerPlantMapper
    {
        public static PowerPlantDto ToDto(this PowerPlant entity)
            => new PowerPlantDto(entity.Owner, entity.Power, entity.ValidFrom, entity.ValidTo);
    }
}
