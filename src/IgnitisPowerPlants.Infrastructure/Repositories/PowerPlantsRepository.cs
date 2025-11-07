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

        public async Task<IEnumerable<PowerPlant>> GetAsync() => 
            await _dbContext.PowerPlants.ToListAsync();
    }
}
