using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;
using IMS.Pugins.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore.Repositories;

public class ProductTransactionRepository : IProductTransactionRepository
{
    private readonly IMSContext _context;
    private readonly IProductRepository _productRepository;
    private readonly DbSet<ProductTransaction> _table;

    public ProductTransactionRepository(IMSContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
        _table = _context.Set<ProductTransaction>();
    }

    public async Task<IEnumerable<ProductTransaction>> GetTransactionsAsync(string name, DateTime? from, DateTime? to, ProductTransactionType? transactionType)
    {
        var transactions = _table.Where(x =>
                                    (string.IsNullOrWhiteSpace(name) || x.Product.Name.Contains(name))
                                    &&
                                    (!from.HasValue || x.Date >= from.Value.Date)
                                    &&
                                    (!to.HasValue || x.Date <= to.Value.AddDays(1).Date)
                                    &&
                                    (!transactionType.HasValue || x.Type == transactionType)
                                ); 

        return await transactions.ToListAsync();
    }

    public async Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
    {
        var dbProduct = await _productRepository.GetByIdAsync(product.Id);

        if (dbProduct != null)
        {
            dbProduct.ProductInvertories.ToList().ForEach(async pi =>
            {
                int quantityBefore = pi.Invertory.Quantity;
                pi.Invertory.Quantity -= quantity * pi.InvertoryQuantity;

                await _context.InvertoryTransactions.AddAsync(new InvertoryTransaction()
                {
                    ProductionNumber = productionNumber,
                    InvertoryId = pi.InvertoryId,
                    QuantityBefore = quantityBefore,
                    QuantityAfter = pi.Invertory.Quantity,
                    Type = InvertoryTransactionType.ProduceProduct,
                    Date = DateTime.Now,
                    DoneBy = doneBy,
                    UnitPrice = price,
                    Id = Guid.NewGuid(),
                                        
                });
            });
        }

        _table.Add(new ProductTransaction
        {
            ProductionNumber = productionNumber,
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            QuantityBefore = product.Quantity,
            Type = ProductTransactionType.ProduceProduct,
            QuantityAfter = product.Quantity + quantity,
            Date = DateTime.Now,
            DoneBy = doneBy,
            UnitPrice = price
        });

        await _context.SaveChangesAsync();
    }

    public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy)
    {
        _table.Add(new ProductTransaction
        {
            SalesOrderNumber = salesOrderNumber,
            ProductId = product.Id,
            Id = Guid.NewGuid(),
            QuantityBefore = product.Quantity,
            QuantityAfter = product.Quantity - quantity,
            Date = DateTime.Now,
            DoneBy = doneBy,
            UnitPrice = price,
            Type = ProductTransactionType.SellProduct
        });

        await _context.SaveChangesAsync();
    }
}
