using IgnitisPowerPlants.Application.Interfaces;
using IgnitisPowerPlants.Domain.Entities;
using IgnitisPowerPlants.Infrastructure.Persistence;
using IgnitisPowerPlants.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IgnitisPowerPlants.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(connectionString)
                .UseSeeding((dbContext, _) => { // Triggers on Update-Database or EnsureActive()
                    var powerPlantsExist = dbContext.Set<PowerPlant>().Any();
                    if (!powerPlantsExist)
                    {
                        dbContext.Set<PowerPlant>().AddRange(TestData.GetPowerPlants());
                        dbContext.SaveChanges();
                    }
                })
            );
            services.AddScoped<IPowerPlantsRepository, PowerPlantsRepository>();

            return services;
        }
    }
}
