using Microsoft.AspNetCore.Mvc;
using ecommarce.BLL.services;
using ecommarce.BLL.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ecommarnce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductservices _productService;

    public ProductController(IProductservices productService)
    {
        _productService = productService;
    }

  
    [HttpGet]
    [Authorize(Roles ="Admin,User")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.Getall();
        return Ok(result);
    }


    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task <IActionResult> GetById(Guid id)
    {
        var result = await _productService.GetById(id);

        if (result == null)
            return NotFound("Product not found");

        return Ok(result);
    }


    [HttpPost]
    [Authorize(Roles ="Admin")]
    public async Task <IActionResult> Add(ProductAddDto product)
    {
     await   _productService.Add(product);
        return Ok("Product added successfully");
    }

    [HttpPut]
    [Authorize(Roles ="Admin")]
    public async Task <IActionResult> Update(ProductUpdateDto product)
    {
        try
        {
           await _productService.Update(product);
            return Ok("Product updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task <IActionResult> Delete(Guid id)
    {
        try
        {
           await _productService.Delete(id);
            return Ok("Product deleted successfully");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}