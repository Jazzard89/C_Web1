using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Slide06ModelValidation.CustomModelValidations
{
    public class CustomDate : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var dtm = DateTime.Now;
            var lst = new List<ModelValidationResult>();
            if (DateTime.TryParse(context.Model.ToString(), out dtm))
            {
                if (dtm > DateTime.Now)
                {
                    lst.Add(new ModelValidationResult("", "Date of Birth cannot be in the Future"));
                }
                else if (dtm < DateTime.Now)
                {
                    lst.Add(new ModelValidationResult("", "Date of Birth should not be before 1900"));
                }
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Not a valid date!"));
            }
            return lst;
        }
    }
}
