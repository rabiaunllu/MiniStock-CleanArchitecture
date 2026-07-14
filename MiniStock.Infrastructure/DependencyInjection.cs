/*AppDbContext kaydı
SQLite bağlantısı
IProductRepository → ProductRepository eşleştirmesi*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniStock.Application;

namespace MiniStock.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // SQLite veritabanı bağlantısı
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        // Repository eşleştirmesi
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}