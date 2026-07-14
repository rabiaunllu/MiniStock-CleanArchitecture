using MiniStock.Domain;

namespace MiniStock.Application;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task SaveChangesAsync();
}