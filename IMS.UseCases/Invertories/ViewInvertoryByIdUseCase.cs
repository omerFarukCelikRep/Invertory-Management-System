using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Invertories;

public class ViewInvertoryByIdUseCase : IViewInvertoryByIdUseCase
{
    private readonly IInvertoryRepository _invertoryRepository;

    public ViewInvertoryByIdUseCase(IInvertoryRepository invertoryRepository)
    {
        _invertoryRepository = invertoryRepository;
    }
    public async Task<Invertory?> ExecuteAsync(Guid id)
    {
        return await _invertoryRepository.GetByIdAsync(id);
    }
}
