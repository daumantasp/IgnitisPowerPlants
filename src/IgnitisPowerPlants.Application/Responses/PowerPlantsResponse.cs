using IgnitisPowerPlants.Application.Dtos;

namespace IgnitisPowerPlants.Application.Responses
{
    internal class PowerPlantsResponse
    {
        public required List<PowerPlantDto> PowerPlants { get; set; }
    }
}
