using MediatR;
// Artık ProductDto'yu kullanacağız
using MiniStock.Application.Products; 

namespace MiniStock.Application.Products.GetProducts;

// List<Product> yerine List<ProductDto>
public record GetProductsQuery : IRequest<List<ProductDto>>;