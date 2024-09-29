using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Oef4MvcClientLocation.CustomModelValidation
{
    public class CustomNoNumbers : Attribute, IModelValidator
    {

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var results = new List<ModelValidationResult>();
            string? clientName = context.Model as string;
            if (clientName != null && clientName.Any(char.IsDigit))
            {
                results.Add(new ModelValidationResult("", "contains numbers"));
            }
            return results;
        }
    }
}
