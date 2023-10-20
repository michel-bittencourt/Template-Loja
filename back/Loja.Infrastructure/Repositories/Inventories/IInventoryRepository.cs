using Loja.Domain.Entities;

namespace Loja.Infrastructure.Repositories.Inventories;

public interface IInventoryRepository
{
    Task<IEnumerable<InventoryEntity>> GetAllInventoryAsync();
    Task<InventoryEntity> GetInventoryByIdAsync(int productId);
}
