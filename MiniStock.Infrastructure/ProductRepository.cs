using Microsoft.EntityFrameworkCore;
using MiniStock.Application;
using MiniStock.Domain;

namespace MiniStock.Infrastructure;

// Application katmanındaki IProductRepository arayüzünü (sözleşmesini) uyguluyoruz
public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    // Veritabanı köprümüzü (AppDbContext) içeri alıyoruz
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        // Ürünü Entity Framework'ün takip listesine ekler (Insert hazırlığı)
        await _context.Products.AddAsync(product);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        // Verilen ID'ye göre veritabanında arama yapar (Select by ID)
        return await _context.Products.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        // Tablodaki tüm kayıtları bir liste olarak getirir (Select All)
        return await _context.Products.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        // Hafızada bekleyen tüm Insert/Update işlemlerini veritabanına kesin olarak kaydeder (Commit)
        await _context.SaveChangesAsync();
    }
}