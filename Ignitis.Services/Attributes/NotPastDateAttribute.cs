using System.ComponentModel.DataAnnotations;

namespace Ignitis.Services.Attributes
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        public NotPastDateAttribute()
        {
            ErrorMessage = "The {0} cannot be earlier than today."; // a fallback message
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTimeOffset date)
            {
            
                if (date.Date < DateTimeOffset.UtcNow.Date)
                    return new ValidationResult(string.Format(ErrorMessage!, validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
