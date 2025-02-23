
namespace ConstructionManagementAssistant_Core.Helper.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FutureDateAttribute : ValidationAttribute
    {
        private string? _referenceProperty;

        public FutureDateAttribute() { }

        public FutureDateAttribute(string referenceProperty)
        {
            _referenceProperty = referenceProperty;
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            // For optional dates
            if (value is null) return ValidationResult.Success;

            if (value is not DateOnly endDate)
            {
                return new ValidationResult("Invalid date type");
            }

            DateOnly comparisonDate;

            if (_referenceProperty == null)
            {
                // Compare with today
                comparisonDate = DateOnly.FromDateTime(DateTime.Today);
            }
            else
            {
                // Get reference property value
                var property = validationContext.ObjectType
                    .GetProperty(_referenceProperty);

                if (property == null)
                {
                    return new ValidationResult($"Unknown property {_referenceProperty}");
                }

                var referenceValue = property.GetValue(validationContext.ObjectInstance);
                if (referenceValue == null)
                {
                    return new ValidationResult($"{_referenceProperty} cannot be null");
                }

                comparisonDate = referenceValue switch
                {
                    DateOnly date => date,
                    DateTime datetime => DateOnly.FromDateTime(datetime),
                    _ => throw new ValidationException(
                        $"Invalid type for {_referenceProperty}")
                };
            }

            return endDate > comparisonDate
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage ??
                    $"Date must be after {comparisonDate:yyyy-MM-dd}");
        }
    }
}
