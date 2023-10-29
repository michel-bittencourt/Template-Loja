using AutoMapper;
using Loja.Application.DTO;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces;

namespace Loja.Application.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    //private readonly IGeneralRepository _generalRepository;
    private readonly IMapper _mapper;

    public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        //_generalRepository = generalRepository;
        _mapper = mapper;
    }

    public async Task<InventoryDTO> AddInventory(InventoryDTO inventoryDto)
    {
        try
        {
            var inventory = _mapper.Map<InventoryEntity>(inventoryDto);
            _inventoryRepository.Add(inventory);

            if (await _inventoryRepository.SaveChangesAsync())
                return inventoryDto;

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<InventoryDTO> UpdateInventory(int inventoryId, InventoryDTO inventoryDto)
    {
        try
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
            inventory = _mapper.Map<InventoryEntity>(inventoryDto);

            _inventoryRepository.Update(inventory);

            if (await _inventoryRepository.SaveChangesAsync())
                return inventoryDto;

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteInventory(int inventoryId)
    {
        try
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);

            _inventoryRepository.Delete(inventory);

            return await _inventoryRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<InventoryDTO>> GetAllInventoriesAsync()
    {
        try
        {
            var inventories = await _inventoryRepository.GetAllInventoriesAsync();

            if (inventories == null)
                return null;

            return _mapper.Map<IEnumerable<InventoryDTO>>(inventories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<InventoryDTO> GetInventoryByIdAsync(int inventoryId)
    {
        try
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
            if (inventory == null)
                return null;

            return _mapper.Map<InventoryDTO>(inventory);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
