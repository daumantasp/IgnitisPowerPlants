namespace IgnitisPowerPlants.Application.Validation.PowerPlant
{
    internal class PowerPlantValidationErrorMessageFactory
    {
        private static readonly IReadOnlyDictionary<PowerPlantValidationError, string> _messages = new Dictionary<PowerPlantValidationError, string>
        {
            { PowerPlantValidationError.OwnerNotProvided, "Owner is required." },
            { PowerPlantValidationError.PowerNotProvided, "Power is required." },
            { PowerPlantValidationError.ValidFromNotProvided, "Valid From is required." },
            { PowerPlantValidationError.OwnerInvalidFormat, "Owner must be in the format 'Name Surname'." },
            { PowerPlantValidationError.PowerOutOfRange, "Power must be between 0 and 200." },
            { PowerPlantValidationError.ValidFromAfterValidTo, "Valid From cannot be later than Valid To." }
        };

    public static PowerPlantValidationErrorMessage Create(PowerPlantValidationError error)
        => new PowerPlantValidationErrorMessage(error, _messages[error]);
    }
};
