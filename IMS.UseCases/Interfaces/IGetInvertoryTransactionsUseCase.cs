using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;

namespace IMS.UseCases.Interfaces;

public interface IGetInvertoryTransactionsUseCase
{
    Task<IEnumerable<InvertoryTransaction>> ExecuteAsync(string name, DateTime? from, DateTime? to, InvertoryTransactionType? transactionType);
}
