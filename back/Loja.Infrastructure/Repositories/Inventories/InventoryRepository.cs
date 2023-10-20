using Loja.Domain.Entities;
using Loja.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories.Inventories;

public class InventoryRepository : IInventoryRepository
{
    private readonly ApplicationDbContext _context;

    public InventoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<InventoryEntity>> GetAllInventoryAsync()
    {
        var query = await _context.Inventories.OrderBy(i => i.Name).ToListAsync();

        return query;
    }

    public async Task<InventoryEntity> GetInventoryByIdAsync(int productId)
    {
        var query = await _context.Inventories.FindAsync(productId);

        return query;
    }
}
