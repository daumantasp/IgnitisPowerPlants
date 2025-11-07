using IgnitisPowerPlants.Domain.Entities;

namespace IgnitisPowerPlants.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static void SeedPowerPlants(ApplicationDbContext dbContext)
        {
            if (dbContext.PowerPlants.Any())
            {
                return;
            }

            dbContext.AddRange(
                new PowerPlant
                {
                    Owner = "Vardenis Pavardenis",
                    Power = 9.3m,
                    ValidFrom = new DateOnly(2020, 1, 1),
                    ValidTo = new DateOnly(2025, 1, 1)
                },
                new PowerPlant
                {
                    Owner = "Jonas Jonaitis",
                    Power = 5.7m,
                    ValidFrom = new DateOnly(2021, 6, 15),
                    ValidTo = new DateOnly(2026, 6, 15)
                },
                new PowerPlant
                {
                    Owner = "Ona Petraitė",
                    Power = 12.5m,
                    ValidFrom = new DateOnly(2019, 9, 10),
                    ValidTo = null
                });

            dbContext.SaveChanges();
        }
    }
}
