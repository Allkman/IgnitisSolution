using System.ComponentModel.DataAnnotations;

namespace Ignitis.Services.Attributes
{
    public class OwnerNameAttribute : ValidationAttribute
    {
        public OwnerNameAttribute()
        {
            ErrorMessage = "The {0} field must consist of first name and last name, letters only."; // a fallback message
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string owner)
            {
                if (string.IsNullOrWhiteSpace(owner))
                    return new ValidationResult(ErrorMessage);

                var parts = owner.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2 || !parts.All(p => p.All(char.IsLetter)))
                    return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
