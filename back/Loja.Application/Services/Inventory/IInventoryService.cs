using Loja.Application.DTO;

namespace Loja.Application.Services.Inventory;

public interface IInventoryService
{
    Task<InventoryDTO> AddInventory(InventoryDTO inventoryDto);
    Task<InventoryDTO> UpdateInventory(int inventoryId, InventoryDTO inventoryDto);
    Task<bool> DeleteInventory(int inventoryId);

    Task<IEnumerable<InventoryDTO>> GetAllInventoriesAsync();
    //Task<IEnumerable<InventoryDTO>> GetAllInventoriesByProductAsync(string product);
    Task<InventoryDTO> GetInventoryByIdAsync(int inventoryId);
}
