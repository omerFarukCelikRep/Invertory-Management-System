using IMS.CoreBusiness.Enums;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;

public class InvertoryTransaction
{
    public Guid Id { get; set; }

    [Required]
    public InvertoryTransactionType Type { get; set; }

    [Required]
    public int QuantityBefore { get; set; }

    [Required]
    public int QuantityAfter { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string DoneBy { get; set; }
    public string PONumber { get; set; }
    public string? ProductionNumber { get; set; }
    public double? UnitPrice { get; set; }

    //Navigation Prop.
    [Required]
    public Guid InvertoryId { get; set; }
    public virtual Invertory Invertory { get; set; }
}
