using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Products;

public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByNameUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
    {
        return await _productRepository.GetByNameAsync(name);
    }
}
