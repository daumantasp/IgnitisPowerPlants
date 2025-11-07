namespace IgnitisPowerPlants.Application.Validation.PowerPlant
{
    public enum PowerPlantValidationError
    {
        OwnerNotProvided,
        PowerNotProvided,
        ValidFromNotProvided,
        OwnerInvalidFormat,
        PowerOutOfRange,
        ValidFromAfterValidTo
    }
}
