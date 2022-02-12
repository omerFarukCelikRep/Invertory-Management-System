using IMS.CoreBusiness;

namespace IMS.Pugins.Interfaces;

public interface IInvertoryRepository
{
    Task<IEnumerable<Invertory>> GetByNameAsync(string name);
    Task AddAsync(Invertory invertory);
    Task UpdateAsync(Invertory invertory);
    Task<Invertory?> GetByIdAsync(Guid id);
}
