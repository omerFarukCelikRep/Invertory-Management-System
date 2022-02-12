using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness.Validations;

internal class ProductEnsurePriceGreaterThanInvertoriesPrice : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var product = validationContext.ObjectInstance as Product;
        if (product != null)
        {
            if (!product.ValidatePricing())
            {
                return new ValidationResult($"The product's price is less than the summary of its invertories' price : {product.TotalInvertoryCost()} !", new[] { validationContext.MemberName });
            }
        }

        return ValidationResult.Success;
    }
}
