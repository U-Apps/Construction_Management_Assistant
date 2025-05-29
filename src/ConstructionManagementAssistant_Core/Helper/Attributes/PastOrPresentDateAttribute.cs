
namespace ConstructionManagementAssistant.Core.Helper.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class PastOrPresentDateAttribute : ValidationAttribute
    {
        public bool InclusiveToday { get; set; } = true;

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            // Handle null values (combine with [Required] if needed)
            if (value is null) return ValidationResult.Success;

            if (value is not DateOnly inputDate)
            {
                return new ValidationResult("Invalid date type - must be DateOnly");
            }

            var today = DateOnly.FromDateTime(DateTime.Today);

            var isValid = InclusiveToday
                ? inputDate <= today
                : inputDate < today;

            return isValid
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage ?? GetErrorMessage(today));
        }

        private string GetErrorMessage(DateOnly today) => InclusiveToday
            ? $"Date must be on or before {today:yyyy-MM-dd}"
            : $"Date must be before {today:yyyy-MM-dd}";
    }
}
