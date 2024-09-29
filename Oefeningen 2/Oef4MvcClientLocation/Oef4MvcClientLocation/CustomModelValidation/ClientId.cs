using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Oef4MvcClientLocation.Models;

namespace Oef4MvcClientLocation.CustomModelValidation
{
    public class ClientId : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var results = new List<ModelValidationResult>();

            if (Client.Clients.Any(c => c.ClientId == Convert.ToInt32(context.Model)))
            {
                results.Add(new ModelValidationResult("", "Id bestaat al"));
            }
            if ( Convert.ToInt32(context.Model) < 1)
            {
                results.Add(new ModelValidationResult("", "Id mag niet kleiner zijn dan 1"));
            }

            return results;
        }
    }
}
