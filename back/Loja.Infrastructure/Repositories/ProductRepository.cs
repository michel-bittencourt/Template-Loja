using Loja.Domain.Entities;
using Loja.Domain.Repositories;
using Loja.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<ProductEntity> RemoveProductAsync(ProductEntity product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }


    public async Task<ProductEntity> GetProductByIdAsync(int? id)
    {
        var query = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        return query;
    }

    public async Task<IEnumerable<ProductEntity>> GetProductsAsync()
    {
        var query = await _context.Products
            .OrderBy(p => p.Name)
            .ToListAsync();

        return query;
    }

    public async Task<IEnumerable<ProductEntity>> GetProductsInventoryAsync(int? id)
    {
        var query = await _context.Products
            .Where(p => p.InventoryId == id)
            .OrderBy(p => p.Name)
            .ToListAsync();

        return query;
    }
}
