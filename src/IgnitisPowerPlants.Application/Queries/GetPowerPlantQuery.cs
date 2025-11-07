namespace IgnitisPowerPlants.Application.Queries
{
    public record GetPowerPlantQuery(int? PageNumber, int? PageSize, string? owner);
}
