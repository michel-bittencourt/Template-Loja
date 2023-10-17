using Loja.Domain.Entities;

namespace Loja.Persistence.Repositories.Inventories;

public interface IInventory
{
    Task<Inventory[]> GetAllInventoryAsync();
    Task<Inventory> GetInventoryByIdAsync(int productId);
}
