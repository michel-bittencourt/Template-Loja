using Loja.Domain.Entities;

namespace Loja.Application.Services.Inventories;

public interface IInventoryService
{
    Task<InventoryEntity> AddInventory(InventoryEntity inventory);
    Task<InventoryEntity> UpdateInventory(int inventoryId, InventoryEntity inventory);
    Task<bool> DeleteInventory(int inventoryId);

    Task<InventoryEntity> GetInventoryByIdAsync(int productId);
    Task<IEnumerable<InventoryEntity>> GetAllInventoryAsync();
}
