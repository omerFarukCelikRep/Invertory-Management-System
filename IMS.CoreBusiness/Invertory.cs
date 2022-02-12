using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class Invertory
{
    public Invertory()
    {
        ProductInvertories = new HashSet<ProductInvertory>();
    }
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than zero or equal to {0}")]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]
    public double Price { get; set; }

    public virtual ICollection<ProductInvertory> ProductInvertories { get; set; }
}
