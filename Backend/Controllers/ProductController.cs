using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    [Route("/{category}")]
    public async Task<IActionResult> GetAllProductsAsync([FromRoute] string category)
    {
        var products = await productRepository.GetProductsByCategory(category);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetProductByIdAsync(id);

        if (product is null)
            return NotFound(new { message = "The requested product resource was not found on the server." });
        
        return Ok(product);
    }
}