using IgnitisPowerPlants.Application.Commands;
using System.Text.RegularExpressions;

namespace IgnitisPowerPlants.Application.Validation.PowerPlant
{

    public class PowerPlantValidator
    {
        private readonly PowerPlantValidatorValues _values;

        public PowerPlantValidator(PowerPlantValidatorValues values)
        {
            _values = values;
        }

        public ValidationResult<PowerPlantValidationError> Validate(CreatePowerPlantCommand command)
        {
            var errors = new List<PowerPlantValidationError>();

            if (string.IsNullOrEmpty(command.Owner))
            {
                errors.Add(PowerPlantValidationError.OwnerNotProvided);
            }
            else if (!Regex.IsMatch(command.Owner, _values.OwnerRegex))
            {
                errors.Add(PowerPlantValidationError.OwnerInvalidFormat);
            }

            if (command.Power == null)
            {
                errors.Add(PowerPlantValidationError.PowerNotProvided);
            }
            else if (command.Power < _values.MinPower || command.Power > _values.MaxPower)
            {
                errors.Add(PowerPlantValidationError.PowerOutOfRange);
            }

            if (command.ValidFrom == null)
            {
                errors.Add(PowerPlantValidationError.ValidFromNotProvided);
            }
            else if (command.ValidTo != null && command.ValidFrom > command.ValidTo)
            {
                errors.Add(PowerPlantValidationError.ValidFromAfterValidTo);
            }

            return new ValidationResult<PowerPlantValidationError>(errors.Count == 0, errors);
        }
    }
}
