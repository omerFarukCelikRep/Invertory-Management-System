using IMS.CoreBusiness.Enums;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class ProductTransaction
{
    public Guid Id { get; set; }

    [Required]
    public ProductTransactionType Type { get; set; }

    [Required]
    public int QuantityBefore { get; set; }
    public int QuantityAfter { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string DoneBy { get; set; }
    public string? ProductionNumber { get; set; }
    public string? SalesOrderNumber { get; set; }
    public double? UnitPrice { get; set; }

    //Navigation Prop.
    [Required]
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
}
