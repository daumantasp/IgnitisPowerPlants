namespace IgnitisPowerPlants.Application.Commands
{
    public record CreatePowerPlantCommand(string? Owner, decimal? Power, DateOnly? ValidFrom, DateOnly? ValidTo);
}
