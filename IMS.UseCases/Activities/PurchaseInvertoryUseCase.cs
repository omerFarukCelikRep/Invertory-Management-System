using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Activities;

public class PurchaseInvertoryUseCase : IPurchaseInvertoryUseCase
{
    private readonly IInvertoryTransactionRepository _invertoryTransactionRepository;
    private readonly IInvertoryRepository _invertoryRepository;

    public PurchaseInvertoryUseCase(IInvertoryTransactionRepository invertoryTransactionRepository, IInvertoryRepository invertoryRepository)
    {
        _invertoryTransactionRepository = invertoryTransactionRepository;
        _invertoryRepository = invertoryRepository;
    }
    public async Task ExecuteAsync(string poNumber, Invertory invertory, int quantity, string doneBy)
    {
        await _invertoryTransactionRepository.PurchaseAsync(poNumber, invertory, quantity, invertory.Price, doneBy);

        invertory.Quantity += quantity;

        await _invertoryRepository.UpdateAsync(invertory);
    }
}
