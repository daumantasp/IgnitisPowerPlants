namespace IgnitisPowerPlants.Application.Validation
{
    public record ValidationResult<T>(bool IsValid, List<T> Errors) where T : Enum;
}
