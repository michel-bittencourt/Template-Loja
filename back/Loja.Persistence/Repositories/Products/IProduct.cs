using Loja.Domain.Entities;

namespace Loja.Persistence.Repositories.Products;

public interface IProduct
{
    Task<Product[]> GetAllProductsAsync();
    Task<Product[]> GetAllProductsByInventoryAsync(string inventory);
    Task<Product> GetProductByIdAsync(int productId);
}
