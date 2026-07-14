using MiniStock.Domain;

namespace MiniStock.Application.Products.GetProducts;

// Ürünleri listelemek için dışarıdan parametre almaya gerek yok, boş bir istek yapısı yeterli
public sealed record GetProductsQuery();

public sealed class GetProductsQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> HandleAsync(GetProductsQuery query)
    {
        // Veritabanındaki tüm ürünleri çekip geri döndürüyoruz
        return await _productRepository.GetAllAsync();
    }
}