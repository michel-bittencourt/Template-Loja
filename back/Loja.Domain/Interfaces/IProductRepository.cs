using Loja.Domain.Entities;

namespace Loja.Domain.Repositories;

public interface IProductRepository
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void DeleteRange<T>(IEnumerable<T> entity) where T : class;

    Task<bool> SaveChangesAsync();
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<IEnumerable<ProductEntity>> GetAllProductsByInventoryAsync(string inventory);
    Task<ProductEntity> GetProductByIdAsync(int productId);
}
