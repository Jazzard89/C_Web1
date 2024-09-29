using System.ComponentModel.DataAnnotations;

namespace ProefExamen2.CustomModelValidations
{
    public class TitleValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value.ToString().Substring(0, 4) == "The ")
            {
                return new ValidationResult("De title mag niet beginnen met 'The', dit moet achteraan staan");
            }
            return ValidationResult.Success;
        }
    }
}
