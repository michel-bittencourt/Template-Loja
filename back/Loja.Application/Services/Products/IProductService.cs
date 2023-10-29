using Loja.Application.DTO;

namespace Loja.Application.Services.Products;

public interface IProductService
{
    Task<ProductDTO> AddProduct(ProductDTO productDTO);
    Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO);
    Task<bool> DeleteProduct(int productId);

    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<IEnumerable<ProductDTO>> GetAllProductsByInventoryAsync(string inventory);
    Task<ProductDTO> GetProductByIdAsync(int productId);
}
