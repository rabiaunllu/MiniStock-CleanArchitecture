using MediatR;

namespace MiniStock.Application.Products.DecreaseStock;

public sealed record DecreaseStockCommand(
    Guid ProductId,
    int Quantity
) : IRequest;