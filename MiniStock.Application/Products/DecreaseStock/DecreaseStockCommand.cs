using System;

namespace MiniStock.Application.Products.DecreaseStock;

// Hangi ürünün stoğunun ne kadar azaltılacağını söyleyen istek sınıfı
public sealed record DecreaseStockCommand(Guid ProductId, int Quantity);

public sealed class DecreaseStockCommandHandler
{
    private readonly IProductRepository _productRepository;

    public DecreaseStockCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task HandleAsync(DecreaseStockCommand command)
    {
        // 1. Ürünü ID ile veritabanından bulmaya çalışıyoruz
        var product = await _productRepository.GetByIdAsync(command.ProductId);
        
        if (product == null)
            throw new Exception("Ürün bulunamadı!");

        // 2. Domain katmanındaki iş kuralı metodumuzu çalıştırıyoruz
        // Eğer miktar stoktan fazlaysa bu metot kendi içinde hata fırlatacak
        product.DecreaseStock(command.Quantity);

        // 3. Değişiklikleri kaydediyoruz
        await _productRepository.SaveChangesAsync();
    }
}