using IgnitisPowerPlants.Application.Dtos;

namespace IgnitisPowerPlants.Application.Responses
{
    public class PowerPlantsResponse
    {
        public required List<PowerPlantDto> PowerPlants { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
