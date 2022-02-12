using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Invertories;

public class EditInvertoryUseCase : IEditInvertoryUseCase
{
    private readonly IInvertoryRepository _invertoryRepository;

    public EditInvertoryUseCase(IInvertoryRepository invertoryRepository)
    {
        _invertoryRepository = invertoryRepository;
    }

    public async Task ExecuteAsync(Invertory invertory)
    {
        await _invertoryRepository.UpdateAsync(invertory);
    }
}
