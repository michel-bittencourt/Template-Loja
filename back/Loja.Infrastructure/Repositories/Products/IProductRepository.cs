using Loja.Domain.Entities;

namespace Loja.Infrastructure.Repositories.Products;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<IEnumerable<ProductEntity>> GetAllProductsByInventoryAsync(int inventoryId);
    Task<ProductEntity> GetProductByIdAsync(int productId);
}
