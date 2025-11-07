using IgnitisPowerPlants.Application.Interfaces;
using IgnitisPowerPlants.Domain.Entities;
using IgnitisPowerPlants.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IgnitisPowerPlants.Infrastructure.Repositories
{
    internal class PowerPlantsRepository : IPowerPlantsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PowerPlantsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PowerPlant>> GetAsync(int pageNumber, int pageSize) =>
            await _dbContext.PowerPlants
            .OrderBy(pp => pp.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
