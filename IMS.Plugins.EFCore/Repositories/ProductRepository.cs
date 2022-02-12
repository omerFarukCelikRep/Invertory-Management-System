using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMSContext _context;
    private readonly DbSet<Product> _table;
    public ProductRepository(IMSContext context)
    {
        _context = context;
        _table = _context.Set<Product>();
    }

    public async Task AddAsync(Product product)
    {
        bool hasProduct = await _table.AnyAsync(x => x.Name.Equals(product.Name));

        if (hasProduct)
        {
            return;
        }

        try
        {
            await _table.AddAsync(product);
            var result = await _context.SaveChangesAsync();
        }
        catch { }
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _table.FindAsync(id);

        if (product != null)
        {
            product.IsActive = false;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetByNameAsync(string name)
    {
        return await _table
                            .Where(x => (x.Name.Contains(name) || string.IsNullOrWhiteSpace(name)) && x.IsActive)
                            .AsNoTracking()
                            .ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        bool hasProduct = await _table.AnyAsync(x => x.Id != product.Id && x.Name.Equals(product.Name));

        if (hasProduct)
        {
            return;
        }

        var updatedProduct = await _table.FindAsync(product.Id);

        if (updatedProduct != null)
        {
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            updatedProduct.Quantity = product.Quantity;
            updatedProduct.ProductInvertories = product.ProductInvertories;

            await _context.SaveChangesAsync();
        }


    }
}
