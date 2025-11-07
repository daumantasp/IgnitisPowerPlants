namespace IgnitisPowerPlants.Domain.Entities
{
    public class PowerPlant
    {
        public int Id { get; set; }
        public required string Owner { get; set; }
        public decimal Power { get; set; }
        public DateOnly ValidFrom { get; set; }
        public DateOnly? ValidTo { get; set; }
    }
}
