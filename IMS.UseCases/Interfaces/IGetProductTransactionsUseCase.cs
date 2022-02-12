using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;

namespace IMS.UseCases.Interfaces;

public interface IGetProductTransactionsUseCase
{
    Task<IEnumerable<ProductTransaction>> ExecuteAsync(string name, DateTime? from, DateTime? to, ProductTransactionType? transactionType);
}
