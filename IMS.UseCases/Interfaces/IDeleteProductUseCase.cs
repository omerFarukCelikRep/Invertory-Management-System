﻿
namespace IMS.UseCases.Interfaces;

public interface IDeleteProductUseCase
{
    Task ExecuteAsync(Guid id);
}
