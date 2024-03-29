﻿using Loja.Application.DTO;
using Loja.Application.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebAPI.Controllers;


[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    #region Métodos
    [HttpPost, Route("api/product")]
    public async Task<IActionResult> Post(ProductDTO productDto)
    {
        try
        {
            await _productService.AddProduct(productDto);

            if (productDto == null)
                return BadRequest();

            return Created($"api/product/" + productDto.Id, productDto);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpPut("api/product")]
    public async Task<IActionResult> Put(int productId, ProductDTO productDto)
    {
        try
        {
            if (productDto == null)
                return NotFound();

            await _productService.UpdateProduct(productId, productDto);

            return Ok(productDto);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpDelete("api/product/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteProduct(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpGet, Route("api/product")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var products = await _productService.GetAllProductsAsync();

            if (products == null)
                return NotFound();

            return Ok(products);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }

    [HttpGet, Route("api/product/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong, please contact the developers. Error: {ex.Message}");
        }
    }
    #endregion
}