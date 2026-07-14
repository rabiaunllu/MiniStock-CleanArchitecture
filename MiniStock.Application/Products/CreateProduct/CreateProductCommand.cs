using MediatR;

namespace MiniStock.Application.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    decimal UnitPrice,
    int StockQuantity
) : IRequest;