using MediatR;
using MiniStock.Domain;
using MiniStock.Application.Common.Exceptions; // Bu çok önemli!

namespace MiniStock.Application.Products.CreateProduct;

public sealed class CreateProductCommandHandler 
    : IRequestHandler<CreateProductCommand, Guid> // Guid dönmesini istediğimiz için bunu ekledik
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // 1. KONTROL: İsim çakışması var mı?
        if (await _productRepository.ExistsByNameAsync(request.Name, cancellationToken))
        {
            // Özel hata sınıfımızı kullanıyoruz
            throw new ConflictException("Bu isimde bir ürün zaten mevcut."); 
        }

        // 2. İŞLEM: Ürünü oluştur
        var product = new Product(request.Name, request.UnitPrice, request.StockQuantity);

        // 3. KAYDET: Veritabanına gönder
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        
        return product.Id;
    }
}