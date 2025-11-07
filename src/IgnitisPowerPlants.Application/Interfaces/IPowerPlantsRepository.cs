using IgnitisPowerPlants.Domain.Entities;

namespace IgnitisPowerPlants.Application.Interfaces
{
    public interface IPowerPlantsRepository
    {
        Task<IEnumerable<PowerPlant>> GetAsync();
    }
}
