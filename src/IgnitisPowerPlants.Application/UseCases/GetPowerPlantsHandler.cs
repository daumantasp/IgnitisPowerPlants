using IgnitisPowerPlants.Application.Interfaces;
using IgnitisPowerPlants.Application.Mapper;
using IgnitisPowerPlants.Application.Responses;

namespace IgnitisPowerPlants.Application.UseCases
{
    public class GetPowerPlantsHandler
    {
        private readonly IPowerPlantsRepository _powerPlantsRepository;
        public GetPowerPlantsHandler(IPowerPlantsRepository powerPlantsRepository)
        {
            _powerPlantsRepository = powerPlantsRepository;
        }

        public async Task<PowerPlantsResponse> HandleAsync()
        {
            var powerPlants = await _powerPlantsRepository.GetAsync();
            var powerPlantsDtos = powerPlants.Select(pp => pp.ToDto()).ToList();

            return new PowerPlantsResponse { PowerPlants = powerPlantsDtos };
        }
    }
}
