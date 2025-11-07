using IgnitisPowerPlants.Application.Validation.PowerPlant;

namespace IgnitisPowerPlants.Application.Exceptions
{
    public class PowerPlantValidationException : Exception
    {
        public PowerPlantValidationError Error { get; init; }

        public PowerPlantValidationException(PowerPlantValidationErrorMessage errorMessage)
            : base(errorMessage.Message)
        {
            Error = errorMessage.Error;
        }
    }
}
