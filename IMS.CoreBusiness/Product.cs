using IMS.CoreBusiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
        ProductInvertories = new HashSet<ProductInvertory>();
    }
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]
    [ProductEnsurePriceGreaterThanInvertoriesPrice]
    public double Price { get; set; }
    public bool IsActive { get; set; } = true;

    //Navigation Prop.
    public virtual ICollection<ProductInvertory> ProductInvertories { get; set; }

    public double TotalInvertoryCost()
    {
        return ProductInvertories.Sum(x => x.Invertory?.Price * x.InvertoryQuantity ?? 0);
    }

    public bool ValidatePricing()
    {
        if (ProductInvertories == null || ProductInvertories.Count <= 0)
        {
            return true;
        }

        if (TotalInvertoryCost() > Price)
        {
            return false;
        }

        return true;
    }
}
