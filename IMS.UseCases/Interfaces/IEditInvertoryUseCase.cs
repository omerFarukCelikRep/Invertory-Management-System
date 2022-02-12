using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IEditInvertoryUseCase
{
    Task ExecuteAsync(Invertory invertory);
}
