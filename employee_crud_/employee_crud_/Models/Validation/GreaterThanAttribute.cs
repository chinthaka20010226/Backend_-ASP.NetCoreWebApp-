using System.ComponentModel.DataAnnotations;

namespace employee_crud_.Models.Validation
{
    public class GreaterThanAttribute : ValidationAttribute
    {
        private readonly int _lowerLimit;

        public GreaterThanAttribute(int lowerLimit)
        {
            _lowerLimit = lowerLimit;
        }

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                if(value is int intValue)
                {
                    if(intValue <= _lowerLimit)
                    {
                        return new ValidationResult($"The field {validationContext.DisplayName} must be greater than {_lowerLimit}.");
                    }
                }
                else
                {
                    throw new ArgumentException($"The value provided is not an interger.");
                }
            }

            return ValidationResult.Success;
        }
    }
}