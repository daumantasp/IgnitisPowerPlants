namespace IgnitisPowerPlants.Application.Validation.PowerPlant
{
    public record PowerPlantValidatorValues(string OwnerRegex, decimal MinPower, decimal MaxPower);
}
