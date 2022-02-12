using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Activities;

public class ProduceProductUseCase : IProduceProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IProductTransactionRepository _productTransactionRepository;

    public ProduceProductUseCase(IProductRepository productRepository, IProductTransactionRepository productTransactionRepository)
    {
        _productRepository = productRepository;
        _productTransactionRepository = productTransactionRepository;
    }

    public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy)
    {
        await _productTransactionRepository.ProduceAsync(productionNumber, product, quantity, product.Price, doneBy);

        product.Quantity += quantity;
        await _productRepository.UpdateAsync(product);
    }
}
