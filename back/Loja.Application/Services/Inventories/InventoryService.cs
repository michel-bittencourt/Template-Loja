using Loja.Domain.Entities;
using Loja.Infrastructure.Repositories.General;
using Loja.Infrastructure.Repositories.Inventories;

namespace Loja.Application.Services.Inventories;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IGeneralRepository _generalRepository;

    public InventoryService(IInventoryRepository inventory, IGeneralRepository general)
    {
        _inventoryRepository = inventory;
        _generalRepository = general;
    }

    public async Task<InventoryEntity> AddInventory(InventoryEntity inventory)
    {
        try
        {
            _generalRepository.Add(inventory);

            if (await _generalRepository.SaveChangesAsync())
            {
                return await _inventoryRepository.GetInventoryByIdAsync(inventory.Id);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<InventoryEntity> UpdateInventory(int inventoryId, InventoryEntity inventory)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteInventory(int inventoryId)
    {
        throw new NotImplementedException();
    }

    public Task<InventoryEntity> GetInventoryByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InventoryEntity>> GetAllInventoryAsync()
    {
        throw new NotImplementedException();
    }
}
