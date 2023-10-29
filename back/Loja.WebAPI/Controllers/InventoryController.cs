using Loja.Application.DTO;
using Loja.Application.Services.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebAPI.Controllers;

[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;
    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpPost, Route("api/inventory")]
    public async Task<IActionResult> Post(InventoryDTO inventoryDto)
    {
        try
        {
            await _inventoryService.AddInventory(inventoryDto);

            if (inventoryDto == null)
                return BadRequest();

            return Created("api/inventory" + inventoryDto.Id, inventoryDto);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpPut, Route("api/inventory/{inventoryId}")]
    public async Task<IActionResult> Put(int inventoryId, InventoryDTO inventoryDto)
    {
        try
        {
            await _inventoryService.UpdateInventory(inventoryId, inventoryDto);

            if (inventoryDto == null)
                return NotFound();

            return Ok(inventoryDto);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpDelete, Route("api/inventory/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);

            if (inventory == null)
                return NotFound();

            await _inventoryService.DeleteInventory(inventory.Id);

            return Ok();
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpGet, Route("api/inventory")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var inventories = await _inventoryService.GetAllInventoriesAsync();

            if (inventories == null)
                return NotFound();

            return Ok(inventories);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpGet, Route("api/inventory/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);

            if (inventory == null)
                return NotFound();

            return Ok(inventory);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }
}
