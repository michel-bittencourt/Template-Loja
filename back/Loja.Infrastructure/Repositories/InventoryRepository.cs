using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly ApplicationDbContext _context;
    public InventoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void DeleteRange<T>(IEnumerable<T> entity) where T : class
    {
        _context.RemoveRange(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<IEnumerable<InventoryEntity>> GetAllInventoriesAsync()
    {
        var query = await _context.Inventories
            .Where(i => i.Active == true)
            .Include(i => i.Products)
            .OrderBy(i => i.Name)
            .ToListAsync();

        return query;
    }

    public async Task<InventoryEntity> GetInventoryByIdAsync(int inventoryId)
    {
        var query = await _context.Inventories
            .FirstOrDefaultAsync(i => i.Active == true && i.Id == inventoryId);

        return query;
    }
}
