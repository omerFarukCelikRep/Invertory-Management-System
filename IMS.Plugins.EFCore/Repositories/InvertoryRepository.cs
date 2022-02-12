using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore.Repositories;

public class InvertoryRepository : IInvertoryRepository
{
    private readonly IMSContext _context;
    private readonly DbSet<Invertory> _table;

    public InvertoryRepository(IMSContext context)
    {
        _context = context;
        _table = _context.Invertories;
    }

    public async Task AddAsync(Invertory invertory)
    {
        bool hasInvertory = await _table.AnyAsync(x => x.Name.Equals(invertory.Name));

        if (hasInvertory)
        {
            return;
        }

        await _table.AddAsync(invertory);
        await _context.SaveChangesAsync();
    }

    public async Task<Invertory?> GetByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<IEnumerable<Invertory>> GetByNameAsync(string name)
    {
        return await _table
                            .Where(x => x.Name.Contains(name) || string.IsNullOrWhiteSpace(name))
                            .AsNoTracking()
                            .ToListAsync();
    }

    public async Task UpdateAsync(Invertory invertory)
    {
        bool hasInvertory = await _table.AnyAsync(x => x.Id != invertory.Id && x.Name.Equals(invertory.Name));

        if (hasInvertory)
        {
            return;
        }

        var updatedInvertory = await _table.FindAsync(invertory.Id);

        if (updatedInvertory != null)
        {
            updatedInvertory.Name = invertory.Name;
            updatedInvertory.Price = invertory.Price;
            updatedInvertory.Quantity = invertory.Quantity;

            await _context.SaveChangesAsync();
        }
    }
}
