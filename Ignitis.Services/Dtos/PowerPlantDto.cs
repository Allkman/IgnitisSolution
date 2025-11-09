using Ignitis.Services.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Ignitis.Services.Dtos
{
    public class PowerPlantDto
    {
        public Guid Id { get; set; }

        [OwnerName(ErrorMessage = "Owner must have exactly two words (letters only).")]
        [Required(ErrorMessage = "The Owner field is required.")]
        public string Owner { get; set; } = string.Empty;

        [Range(0, 200, ErrorMessage = "Power value must be between 0.0 and 200.0 (inclusive).")]
        [Required(ErrorMessage = "The Power field is required.")]
        public decimal? Power { get; set; }

        [Required(ErrorMessage = "The ValidFrom field is required.")]
        public DateTimeOffset? ValidFrom { get; set; }

        [NotPastDate(ErrorMessage = "The ValidTo date cannot be in the past.")]
        public DateTimeOffset? ValidTo { get; set; }
    }
}
