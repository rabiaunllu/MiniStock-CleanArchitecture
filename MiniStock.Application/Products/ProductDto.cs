namespace MiniStock.Application.Products;

public sealed record ProductDto(
    Guid Id,
    string Name,
    decimal UnitPrice,
    int StockQuantity);