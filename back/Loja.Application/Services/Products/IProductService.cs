using Loja.Domain.Entities;

namespace Loja.Application.Services.Products;

public interface IProductService
{
    Task<ProductEntity> AddProductAsync(ProductEntity product);
    Task<ProductEntity> UpdateProductAsync(int productId, ProductEntity product);
    Task<bool> DeleteProductAsync(int productId);

    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<IEnumerable<ProductEntity>> GetAllProductsByInventoryAsync(int inventoryId);
    Task<ProductEntity> GetProductByIdAsync(int productId);
}
