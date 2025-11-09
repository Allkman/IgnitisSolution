using System.ComponentModel.DataAnnotations;

namespace Ignitis.Services.Dtos
{
    public class PaginatedPowerPlantRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than zero.")]
        public int Page { get; set; }

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int PageSize { get; set; }
        public string? Owner { get; set; }
    }
}
