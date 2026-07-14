using MediatR;
using MiniStock.Application.Products;

namespace MiniStock.Application.Products.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        // İşte "elle" yaptığımız dönüşüm burası:
        return products
            .Select(p => new ProductDto(p.Id, p.Name, p.UnitPrice, p.StockQuantity))
            .ToList();
    }
}