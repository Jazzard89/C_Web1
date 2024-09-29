using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Oef4MvcClientLocation.CustomModelValidation
{
    public class CustomPostcode : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var results = new List<ModelValidationResult>();

            string? postCode = context.Model as string;
            if (postCode != null && (postCode != "3500" || postCode != "3600" || postCode != "3990"))
            {
                results.Add(new ModelValidationResult("", "postcode can only contain 3500,3600 and 3990"));
            }
            return results;
        }
    }
}
