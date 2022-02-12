using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;
using IMS.Pugins.Interfaces;

namespace IMS.UseCases.Interfaces;

public class GetProductTransactionsUseCase : IGetProductTransactionsUseCase
{
    private readonly IProductTransactionRepository _productTransactionRepository;

    public GetProductTransactionsUseCase(IProductTransactionRepository productTransactionRepository)
    {
        _productTransactionRepository = productTransactionRepository;
    }

    public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(string name, DateTime? from, DateTime? to, ProductTransactionType? transactionType)
    {
        return await _productTransactionRepository.GetTransactionsAsync(name, from, to, transactionType);
    }
}
