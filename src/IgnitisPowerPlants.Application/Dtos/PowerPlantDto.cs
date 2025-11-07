namespace IgnitisPowerPlants.Application.Dtos
{
    public record PowerPlantDto(string Owner, decimal Power, DateOnly ValidFrom, DateOnly? ValidTo);
}
