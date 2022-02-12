using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Interfaces;

public class GetInvertoryTransactionsUseCase : IGetInvertoryTransactionsUseCase
{
    private readonly IInvertoryTransactionRepository _invertoryTransactionRepository;

    public GetInvertoryTransactionsUseCase(IInvertoryTransactionRepository invertoryTransactionRepository)
    {
        _invertoryTransactionRepository = invertoryTransactionRepository;
    }
    public async Task<IEnumerable<InvertoryTransaction>> ExecuteAsync(string name, DateTime? from, DateTime? to, InvertoryTransactionType? transactionType)
    {
        return await _invertoryTransactionRepository.GetTransactionsAsync(name, from, to, transactionType);
    }
}
