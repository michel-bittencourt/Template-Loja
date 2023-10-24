using Loja.Domain.Entities;

namespace Loja.Domain.Repositories;

public interface IProductRepository
{
    Task<ProductEntity> CreateProductAsync(ProductEntity product);
    Task<ProductEntity> UpdateProductAsync(ProductEntity product);
    Task<ProductEntity> RemoveProductAsync(ProductEntity product);

    Task<ProductEntity> GetProductByIdAsync(int? id);
    Task<IEnumerable<ProductEntity>> GetProductsAsync();
    Task<IEnumerable<ProductEntity>> GetProductsInventoryAsync(int? id);
}
