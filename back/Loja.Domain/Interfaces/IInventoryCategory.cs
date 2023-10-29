using Loja.Domain.Entities;

namespace Loja.Domain.Interfaces;

public interface IInventoryRepository
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void DeleteRange<T>(IEnumerable<T> entity) where T : class;

    Task<bool> SaveChangesAsync();
    Task<IEnumerable<InventoryEntity>> GetAllInventoriesAsync();
    //Task<IEnumerable<InventoryEntity>> GetAllInventoriesByProductAsync(string product);
    Task<InventoryEntity> GetInventoryByIdAsync(int inventoryId);
}
