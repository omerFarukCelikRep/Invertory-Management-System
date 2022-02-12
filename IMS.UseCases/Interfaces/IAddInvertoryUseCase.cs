using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IAddInvertoryUseCase
{
    Task ExecuteAsync(Invertory invertory);
}
