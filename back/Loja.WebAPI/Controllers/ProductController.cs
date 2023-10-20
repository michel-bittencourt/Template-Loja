using Loja.Application.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var products = await _productService.GetAllProductsAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }


}
