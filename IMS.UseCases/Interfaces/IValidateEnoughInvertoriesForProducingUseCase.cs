using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IValidateEnoughInvertoriesForProducingUseCase
{
    Task<bool> ExecuteAsync(Product product, int quantity);
}
