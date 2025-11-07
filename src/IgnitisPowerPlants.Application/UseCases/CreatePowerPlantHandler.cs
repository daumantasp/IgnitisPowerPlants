using IgnitisPowerPlants.Application.Commands;
using IgnitisPowerPlants.Application.Exceptions;
using IgnitisPowerPlants.Application.Interfaces;
using IgnitisPowerPlants.Application.Validation.PowerPlant;
using IgnitisPowerPlants.Domain.Entities;

namespace IgnitisPowerPlants.Application.UseCases
{
    public class CreatePowerPlantHandler
    {
        private readonly IPowerPlantsRepository _powerPlantsRepository;
        private readonly PowerPlantValidator _powerPlantValidator;

        public CreatePowerPlantHandler(IPowerPlantsRepository powerPlantsRepository, PowerPlantValidator powerPlantValidator)
        {
            _powerPlantsRepository = powerPlantsRepository;
            _powerPlantValidator = powerPlantValidator;
        }

        public async Task HandleAsync(CreatePowerPlantCommand command)
        {
            var validationResult = _powerPlantValidator.Validate(command);
            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors
                    .First();
                var errorMessage = PowerPlantValidationErrorMessageFactory.Create(error);
                throw new PowerPlantValidationException(errorMessage);
            }

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
