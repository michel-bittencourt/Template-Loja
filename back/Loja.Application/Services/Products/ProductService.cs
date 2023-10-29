using AutoMapper;
using Loja.Application.DTO;
using Loja.Domain.Entities;
using Loja.Domain.Repositories;

namespace Loja.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    //private readonly IGeneralRepository _generalRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        //_generalRepository = generalRepository;
        _mapper = mapper;
    }

    public async Task<ProductDTO> AddProduct(ProductDTO productDTO)
    {
        try
        {
            var product = _mapper.Map<ProductEntity>(productDTO);
            _productRepository.Add(product);

            if (await _productRepository.SaveChangesAsync())
                return productDTO;

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO)
    {
        try
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            product = _mapper.Map<ProductEntity>(productDTO);
            _productRepository.Update(product);

            if (await _productRepository.SaveChangesAsync())
                return productDTO;

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            _productRepository.Delete(product);

            return await _productRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        try
        {
            var products = await _productRepository.GetAllProductsAsync();

            if (products == null)
                return null;

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsByInventoryAsync(string inventory)
    {
        try
        {
            var products = await _productRepository.GetAllProductsByInventoryAsync(inventory);

            if (products == null)
                return null;

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductDTO> GetProductByIdAsync(int productId)
    {
        try
        {
            var products = await _productRepository.GetProductByIdAsync(productId);

            if (products == null)
                return null;

            return _mapper.Map<ProductDTO>(products);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
