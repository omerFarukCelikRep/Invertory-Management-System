namespace IMS.CoreBusiness
{
    public class ProductInvertory
    {
        public int InvertoryQuantity { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public Guid InvertoryId { get; set; }
        public virtual Invertory? Invertory { get; set; }
    }
}