using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Invertories;

public class AddInvertoryUseCase : IAddInvertoryUseCase
{
    private readonly IInvertoryRepository _invertoryRepository;

    public AddInvertoryUseCase(IInvertoryRepository invertoryRepository)
    {
        _invertoryRepository = invertoryRepository;
    }
    public async Task ExecuteAsync(Invertory invertory)
    {
        if (invertory == null)
        {
            return;
        }

        await _invertoryRepository.AddAsync(invertory);
    }
}
