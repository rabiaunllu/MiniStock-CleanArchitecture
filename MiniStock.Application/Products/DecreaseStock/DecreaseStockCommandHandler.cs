using MediatR;

namespace MiniStock.Application.Products.DecreaseStock;

public sealed class DecreaseStockCommandHandler
    : IRequestHandler<DecreaseStockCommand>
{
    private readonly IProductRepository _productRepository;

    public DecreaseStockCommandHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(
        DecreaseStockCommand command,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(
            command.ProductId);

        if (product is null)
        {
            throw new InvalidOperationException("Ürün bulunamadı.");
        }

        // Stok kontrolü Domain katmanındaki Product tarafından yapılır.
        product.DecreaseStock(command.Quantity);

        await _productRepository.SaveChangesAsync();
    }
}