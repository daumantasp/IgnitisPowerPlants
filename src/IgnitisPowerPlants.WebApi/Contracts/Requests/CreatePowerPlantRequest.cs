namespace IgnitisPowerPlants.WebApi.Contracts.Requests
{
    public class CreatePowerPlantRequest
    {
        public string? Owner { get; set; }
        public decimal? Power { get; set; }
        public DateOnly? ValidFrom { get; set; }
        public DateOnly? ValidTo { get; set; }
    }
}
