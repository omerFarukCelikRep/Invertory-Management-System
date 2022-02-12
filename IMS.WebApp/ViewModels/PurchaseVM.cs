using IMS.CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels;

public class PurchaseVM
{
    [Required]
    public string PurchaseOrder { get; set; }

    [Required]
    public Guid InvertoryId { get; set; }

    [Required]
    public string InvertoryName { get; set; }
    public double InvertoryPrice { get; set; }

    [Required]
    [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than 1!")]
    public int QuantityToPurchase { get; set; }
}
