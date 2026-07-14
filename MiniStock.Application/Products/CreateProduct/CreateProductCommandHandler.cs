using MediatR;
using MiniStock.Domain;

namespace MiniStock.Application.Products.CreateProduct;

public sealed class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var product = new Product(
            command.Name,
            command.UnitPrice,
            command.StockQuantity);

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
    }
}