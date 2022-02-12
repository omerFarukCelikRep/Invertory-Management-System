using IMS.CoreBusiness;
using IMS.CoreBusiness.Enums;
using IMS.Pugins.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore.Repositories;

public class InvertoryTransactionRepository : IInvertoryTransactionRepository
{
    private readonly IMSContext _context;
    private readonly DbSet<InvertoryTransaction> _table;

    public InvertoryTransactionRepository(IMSContext context)
    {
        _context = context;
        _table = _context.Set<InvertoryTransaction>();
    }

    public async Task<IEnumerable<InvertoryTransaction>> GetTransactionsAsync(string name, DateTime? from, DateTime? to, InvertoryTransactionType? transactionType)
    {
        var transactions = _table.Where(x => 
                                    (string.IsNullOrWhiteSpace(name) || x.Invertory.Name.Contains(name)) 
                                    &&
                                    (!from.HasValue || x.Date >= from.Value.Date) 
                                    && 
                                    (!to.HasValue || x.Date <= to.Value.AddDays(1).Date)
                                    && 
                                    (!transactionType.HasValue || x.Type == transactionType)
                                );

        return await transactions.ToListAsync();
    }

    public async Task PurchaseAsync(string poNumber, Invertory invertory, int quantity, double price, string doneBy)
    {
        await _table.AddAsync(new InvertoryTransaction
        {
            Date = DateTime.Now,
            Id = Guid.NewGuid(),
            InvertoryId = invertory.Id,
            PONumber = poNumber,
            QuantityBefore = invertory.Quantity,
            QuantityAfter = invertory.Quantity + quantity,
            Type = InvertoryTransactionType.PurchaseInvertory,
            DoneBy = doneBy,
            UnitPrice = price
        });

        await _context.SaveChangesAsync();
    }
}
