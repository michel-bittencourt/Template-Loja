using Loja.Domain.Entities;
using Loja.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        var query = await _context.Products
            .OrderBy(p => p.Name)
            .ToListAsync();

        return query;
    }

    public async Task<ProductEntity> GetProductByIdAsync(int id)
    {
        var query = await _context.Products.FindAsync(id);

        return query;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsByInventoryAsync(int id)
    {
        var query = await _context.Products
            .Where(p => p.InventoryId == id)
            .OrderBy(p => p.Name)
            .ToListAsync();

        return query;
    }
}
