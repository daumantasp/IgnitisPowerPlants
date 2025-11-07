using IgnitisPowerPlants.Application.Interfaces;
using IgnitisPowerPlants.Application.Mapper;
using IgnitisPowerPlants.Application.Queries;
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

        public async Task<PowerPlantsResponse> HandleAsync(GetPowerPlantQuery query)
        {
            var pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;
            var pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;

            var powerPlants = await _powerPlantsRepository.GetAsync(pageNumber, pageSize, query.owner);
            var powerPlantsDtos = powerPlants.Select(pp => pp.ToDto()).ToList();

            return new PowerPlantsResponse { PowerPlants = powerPlantsDtos, PageNumber = pageNumber, PageSize = pageSize };
        }
    }
}
