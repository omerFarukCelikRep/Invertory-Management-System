using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;

namespace IMS.Pugins.Interfaces;

public interface IInvertoryTransactionRepository
{
    Task PurchaseAsync(string poNumber, Invertory invertory, int quantity, double price, string doneBy);
    Task<IEnumerable<InvertoryTransaction>> GetTransactionsAsync(string name, DateTime? from, DateTime? to, InvertoryTransactionType? transactionType);
}
