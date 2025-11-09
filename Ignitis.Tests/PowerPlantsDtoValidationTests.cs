using Ignitis.Services.Dtos;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Ignitis.Tests
{
    public class PowerPlantDtoValidationTests
    {
        private IList<ValidationResult> ValidateDto(PowerPlantDto dto)
        {
            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(dto, context, results, true);
            return results;
        }

        [Theory]
        [InlineData(null, 50.0, "2025-11-08", null, "The Owner field is required.")]
        [InlineData("", 50.0, "2025-11-08", null, "The Owner field is required.")]
        [InlineData("SingleName", 50.0, "2025-11-08", null, "Owner must have exactly two words (letters only).")]
        [InlineData("Ona Petraite", -5.0, "2025-11-08", null, "Power value must be between 0.0 and 200.0 (inclusive).")]
        [InlineData("Ona Petraite", null, "2025-11-08", null, "The Power field is required.")]
        [InlineData("Ona Petraite", 50.0, null, null, "The ValidFrom field is required.")]
        [InlineData("Ona Petraite", 50.0, "2025-11-08", "2020-01-01", "The ValidTo date cannot be in the past.")]
        public void PowerPlantDto_InvalidFields_ReturnsValidationErrors(
            string? owner, double? powerDouble, string? validFromStr, string? validToStr, string expectedError)
        {
            // Arrange
            // since InlineData uses double convert to decimal is needed
            decimal? power = powerDouble.HasValue ? (decimal?)powerDouble.Value : null;

            var dto = new PowerPlantDto
            {
                Owner = owner ?? string.Empty,
                Power = power,
                ValidFrom = string.IsNullOrEmpty(validFromStr) ? null : DateTimeOffset.Parse(validFromStr),
                ValidTo = string.IsNullOrEmpty(validToStr) ? null : DateTimeOffset.Parse(validToStr)
            };

            // Act
            var results = ValidateDto(dto);

            // Assert
            Assert.Contains(results, r => r.ErrorMessage == expectedError);
        }

        [Fact]
        public void PowerPlantDto_ValidFields_PassesValidation()
        {
            // Arrange
            var dto = new PowerPlantDto
            {
                Owner = "Ona Petraite",
                Power = 50m,
                ValidFrom = DateTimeOffset.UtcNow.AddDays(1),
                ValidTo = DateTimeOffset.UtcNow.AddDays(10)
            };

            // Act
            var results = ValidateDto(dto);

            // Assert
            Assert.Empty(results);
        }
    }
}
