using IgnitisPowerPlants.Application.Commands;
using IgnitisPowerPlants.Application.Interfaces;
using IgnitisPowerPlants.Domain.Entities;

namespace IgnitisPowerPlants.Application.UseCases
{
    public class CreatePowerPlantHandler
    {
        private readonly IPowerPlantsRepository _powerPlantsRepository;

        public CreatePowerPlantHandler(IPowerPlantsRepository powerPlantsRepository)
        {
            _powerPlantsRepository = powerPlantsRepository;
        }

        public async Task HandleAsync(CreatePowerPlantCommand command)
        {
            if (string.IsNullOrEmpty(command.Owner))
                throw new ArgumentException("Owner cannot be null or empty.");
            if (!command.Power.HasValue)
                throw new ArgumentException("Power cannot be null.");
            if (!command.ValidFrom.HasValue)
                throw new ArgumentException("Valid From cannot be null.");

            var entity = new PowerPlant
            {
                Owner = command.Owner,
                Power = command.Power.Value,
                ValidFrom = command.ValidFrom.Value,
                ValidTo = command.ValidTo
            };

            await _powerPlantsRepository.CreateAsync(entity);
        }
    }
}
