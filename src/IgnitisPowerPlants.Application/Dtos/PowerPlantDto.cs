namespace IgnitisPowerPlants.Application.Dtos
{
    internal record PowerPlantDto(string Owner, decimal Power, DateOnly ValidFrom, DateOnly? ValidTo);
}
