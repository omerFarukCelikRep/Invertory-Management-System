using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IPurchaseInvertoryUseCase
{
    Task ExecuteAsync(string poNumber, Invertory invertory, int quantity, string doneBy);
}
