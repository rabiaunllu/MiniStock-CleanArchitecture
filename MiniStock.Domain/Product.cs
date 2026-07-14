using System;

namespace MiniStock.Domain;
//sealed demek bu class inherite alınamaz
public sealed class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int StockQuantity { get; private set; }

    // Ürün oluşturulurken çalışacak Constructor (Yapıcı Metot)
    public Product(string name, decimal unitPrice, int stockQuantity)
    {
        // Kural 1: Ürün adı boş bırakılamaz.
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ürün adı boş bırakılamaz.");

        // Kural 2: Fiyat negatif olamaz.
        if (unitPrice < 0)
            throw new ArgumentException("Fiyat negatif olamaz.");

        // Kural 3: Stok negatif olamaz.
        if (stockQuantity < 0)
            throw new ArgumentException("Stok negatif olamaz.");

        Id = Guid.NewGuid();
        Name = name;
        UnitPrice = unitPrice;
        StockQuantity = stockQuantity;
    }

    // Stok düşürme işlemi için metodumuz
    public void DecreaseStock(int quantity)
    {
        // Düşülecek miktar eksi bir değer olamaz
        if (quantity < 0)
            throw new ArgumentException("Düşülecek miktar negatif olamaz.");

        // Kural 4: Mevcut stoktan fazla ürün düşülemez.
        if (StockQuantity - quantity < 0)
            throw new InvalidOperationException("Mevcut stoktan fazla ürün düşülemez.");

        StockQuantity -= quantity;
    }
}