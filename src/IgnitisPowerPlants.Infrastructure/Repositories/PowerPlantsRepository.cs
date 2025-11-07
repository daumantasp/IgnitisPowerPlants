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

        public async Task<IEnumerable<PowerPlant>> GetAsync(int pageNumber, int pageSize, string? owner)
        {
            var query = _dbContext.PowerPlants.AsQueryable();
            if (!string.IsNullOrEmpty(owner))
            {
                query = query.Where(pp => pp.Owner.ToLower().Contains(owner.ToLower()));
            }
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task CreateAsync(PowerPlant powerPlant)
        {
            _dbContext.PowerPlants.Add(powerPlant);
            return _dbContext.SaveChangesAsync();
        }
    }
}
