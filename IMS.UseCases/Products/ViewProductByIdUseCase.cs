using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Products;

public class ViewProductByIdUseCase : IViewProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> ExecuteAsync(Guid id)
    {
        return await _productRepository.GetByIdAsync(id);
    }
}
