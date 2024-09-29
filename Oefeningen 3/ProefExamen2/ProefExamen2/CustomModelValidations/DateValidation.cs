using System.ComponentModel.DataAnnotations;

namespace ProefExamen2.CustomModelValidations
{
    public class DateValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && (DateTime)value < DateTime.Now.AddDays(-21))
            {
                return new ValidationResult("De datum mag niet verder dan 3 weken in het verleden liggen");
            }
            else
            {
                if (value != null && (DateTime)value > DateTime.Now.AddMonths(3))
                {
                    return new ValidationResult("De datum mag niet verder dan 3 maanden in de toekomst liggen");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }
}
