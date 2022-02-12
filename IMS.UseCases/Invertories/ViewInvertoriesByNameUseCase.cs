using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Invertories;

public class ViewInvertoriesByNameUseCase : IViewInvertoriesByNameUseCase
{
    private readonly IInvertoryRepository _invertoryRepository;

    public ViewInvertoriesByNameUseCase(IInvertoryRepository invertoryRepository)
    {
        _invertoryRepository = invertoryRepository;
    }
    public async Task<IEnumerable<Invertory>> ExecuteAsync(string name = "")
    {
        return await _invertoryRepository.GetByNameAsync(name);
    }
}
