using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;

namespace IMS.Pugins.Interfaces;

public interface IProductTransactionRepository
{
    Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy);
    Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy);
    Task<IEnumerable<ProductTransaction>> GetTransactionsAsync(string name, DateTime? from, DateTime? to, ProductTransactionType? transactionType);
}
