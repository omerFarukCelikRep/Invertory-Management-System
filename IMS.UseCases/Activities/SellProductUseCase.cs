﻿using IMS.CoreBusiness;
using IMS.Pugins.Interfaces;
using IMS.UseCases.Interfaces;

namespace IMS.UseCases.Activities;

public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductTransactionRepository _productTransactionRepository;
    private readonly IProductRepository _productRepository;

    public SellProductUseCase(IProductTransactionRepository productTransactionRepository, IProductRepository productRepository)
    {
        _productTransactionRepository = productTransactionRepository;
        _productRepository = productRepository;
    }
    public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
    {
        await _productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantity, product.Price, doneBy);

        product.Quantity -= quantity;
        await _productRepository.UpdateAsync(product);
    }
}
