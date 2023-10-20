using Loja.Domain.Entities;
using Loja.Infrastructure.Repositories.General;
using Loja.Infrastructure.Repositories.Products;

namespace Loja.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IGeneralRepository _generalRepository;

    public ProductService(IProductRepository productRepository, IGeneralRepository generalRepository)
    {
        _productRepository = productRepository;
        _generalRepository = generalRepository;
    }

    public async Task<ProductEntity> AddProductAsync(ProductEntity product)
    {
        try
        {
            _generalRepository.Add(product);

            if (await _generalRepository.SaveChangesAsync())
            {
                return await _productRepository.GetProductByIdAsync(product.Id);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductEntity> UpdateProductAsync(int productId, ProductEntity product)
    {
        try
        {
            var Product = _productRepository.GetProductByIdAsync(productId);

            if (Product != null)
            {
                _generalRepository.Update(Product);
                if (await _generalRepository.SaveChangesAsync())
                {
                    return await _productRepository.GetProductByIdAsync(product.Id);
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        try
        {
            var Product = _productRepository.GetProductByIdAsync(productId);

            if (Product != null)
            {
                _generalRepository.Delete(Product);
                return await _generalRepository.SaveChangesAsync();
            }
            throw new Exception("Algo errado");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductEntity> GetProductByIdAsync(int productId)
    {
        try
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        try
        {
            var product = await _productRepository.GetAllProductsAsync();
            if (product != null)
            {
                return product;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsByInventoryAsync(int inventoryId)
    {
        try
        {
            var productByInventory = await _productRepository.GetAllProductsByInventoryAsync(inventoryId);
            if (productByInventory != null)
            {
                return productByInventory;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
