using MediatR;
using MiniStock.Domain;

namespace MiniStock.Application.Products.GetProducts;

public sealed class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(
        GetProductsQuery query,
        CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync();
    }
}