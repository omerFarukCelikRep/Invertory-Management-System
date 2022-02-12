using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces;

public interface IViewInvertoryByIdUseCase
{
    Task<Invertory?> ExecuteAsync(Guid id);
}
