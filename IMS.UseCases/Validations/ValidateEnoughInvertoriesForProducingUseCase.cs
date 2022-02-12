using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Validations;

public class ValidateEnoughInvertoriesForProducingUseCase : IValidateEnoughInvertoriesForProducingUseCase
{
    private readonly IProductRepository _productRepository;

    public ValidateEnoughInvertoriesForProducingUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> ExecuteAsync(Product product, int quantity)
    {
        var dbProduct = await _productRepository.GetByIdAsync(product.Id);

        if (dbProduct != null && dbProduct.ProductInvertories.Any(pi => pi.InvertoryQuantity * quantity > pi.Invertory.Quantity))
        {
            return false;
        }


        return true;
    }
}
