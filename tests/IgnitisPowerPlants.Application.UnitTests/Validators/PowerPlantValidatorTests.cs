using FluentAssertions;
using IgnitisPowerPlants.Application.Commands;
using IgnitisPowerPlants.Application.Validation.PowerPlant;

namespace IgnitisPowerPlants.Application.UnitTests.Validators
{
    public class PowerPlantValidatorTests : IDisposable
    {
        private PowerPlantValidatorValues _validatorValues;
        private PowerPlantValidator _validator;

        public PowerPlantValidatorTests()
        {
            _validatorValues = new PowerPlantValidatorValues(
                OwnerRegex: @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž]+\s[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž]+$",
                MinPower: 0m,
                MaxPower: 200m
            );
            _validator = new PowerPlantValidator(_validatorValues);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForOwnerNotProvided()
        {
            var command = new CreatePowerPlantCommand(null, 100m, new DateOnly(2022, 1, 1), null);

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.OwnerNotProvided);
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForOwnerInvalidFormat()
        {
            var command = new CreatePowerPlantCommand("Ona", 100m, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.OwnerInvalidFormat);
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForPowerNotProvided()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", null, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.PowerNotProvided);
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForPowerBelowMinimum()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", -10m, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.PowerOutOfRange);
        }

        [Fact]
        public void Validator_ShouldBeValid_ForPowerEqualToMaximum()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 200m, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Validator_ShouldBeValid_ForPowerEqualToMinimum()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 0m, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForPowerOutOfRange()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 250m, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.PowerOutOfRange);
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForValidFromNotProvided()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 100m, null, null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.ValidFromNotProvided);
        }

        [Fact]
        public void Validator_ShouldReturnErrorMessage_ForValidFromAfterValidTo()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 100m, new DateOnly(2023, 1, 1), new DateOnly(2022, 1, 1));
            var result = _validator.Validate(command);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(PowerPlantValidationError.ValidFromAfterValidTo);
        }

        [Fact]
        public void Validator_ShouldBeValid_ForCorrectCommand()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 150m, new DateOnly(2022, 1, 1), new DateOnly(2023, 1, 1));
            var result = _validator.Validate(command);
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Validator_ShouldBeValid_ForValidToNotProvided()
        {
            var command = new CreatePowerPlantCommand("Ona Petraitė", 100m, new DateOnly(2022, 1, 1), null);
            var result = _validator.Validate(command);
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
