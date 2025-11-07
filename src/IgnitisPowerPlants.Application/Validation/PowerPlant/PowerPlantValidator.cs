using IgnitisPowerPlants.Application.Commands;
using System.Text.RegularExpressions;

namespace IgnitisPowerPlants.Application.Validation.PowerPlant
{
    public class PowerPlantValidator
    {
        public ValidationResult<PowerPlantValidationError> Validate(CreatePowerPlantCommand command)
        {
            var errors = new List<PowerPlantValidationError>();

            if (string.IsNullOrEmpty(command.Owner))
            {
                errors.Add(PowerPlantValidationError.OwnerNotProvided);
            }
            else if (!Regex.IsMatch(command.Owner, @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž]+\s[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž]+$"))
            {
                errors.Add(PowerPlantValidationError.OwnerInvalidFormat);
            }

            if (command.Power == null)
            {
                errors.Add(PowerPlantValidationError.PowerNotProvided);
            }
            else if (command.Power < 0m || command.Power > 200m)
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
