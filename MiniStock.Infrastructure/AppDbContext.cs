using Microsoft.EntityFrameworkCore;
using MiniStock.Domain;

namespace MiniStock.Infrastructure;

// DbContext, projenin veritabanı ile arasındaki köprüdür. 
// Java'daki EntityManager kavramının tam karşılığıdır.
public sealed class AppDbContext : DbContext
{
    // Veritabanında "Products" adında bir tablo oluşacağını belirtiyoruz
    public DbSet<Product> Products { get; set; }

    // Veritabanı bağlantı ayarları
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Karmaşık sunucu kurulumlarına girmemek için hafif bir SQLite dosyası kullanıyoruz
        optionsBuilder.UseSqlite("Data Source=ministock.db");
    }
}