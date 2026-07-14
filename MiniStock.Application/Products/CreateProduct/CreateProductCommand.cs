using MiniStock.Domain;

namespace MiniStock.Application.Products.CreateProduct;

// Dışarıdan gelecek ürün bilgilerini taşıyan basit bir veri yapısı
public sealed record CreateProductCommand(string Name, decimal UnitPrice, int StockQuantity);

public sealed class CreateProductCommandHandler
{
    private readonly IProductRepository _productRepository;

    // Dependency Injection (Bağımlılık Enjeksiyonu) ile Repository'imizi alıyoruz
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task HandleAsync(CreateProductCommand command)
    {
        // Domain katmanındaki Product sınıfını çağırıyoruz. 
        // Kurallara uyulmadıysa constructor burada hata (Exception) fırlatacaktır.
        var product = new Product(command.Name, command.UnitPrice, command.StockQuantity);

        // Veritabanına ekleme emrini veriyoruz
        await _productRepository.AddAsync(product);
        
        // Değişiklikleri kaydediyoruz
        await _productRepository.SaveChangesAsync();
    }
}