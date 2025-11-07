using IgnitisPowerPlants.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace IgnitisPowerPlants.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetPowerPlantsHandler>();
            services.AddScoped<CreatePowerPlantHandler>();

            return services;
        }
    }
}
