using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IViewInvertoriesByNameUseCase
{
    Task<IEnumerable<Invertory>> ExecuteAsync(string name = "");
}
