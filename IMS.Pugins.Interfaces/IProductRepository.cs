using IMS.CoreBusiness;

namespace IMS.Pugins.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetByNameAsync(string name);
    Task AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}
