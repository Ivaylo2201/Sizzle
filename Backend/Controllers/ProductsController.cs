using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository productRepository) : ControllerBase
{
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var products = await productRepository.GetAllProductsAsync();
        return Ok(products);
    }

    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetProductByIdAsync(id);

        if (product is null)
            return NotFound(new { message = "The requested product resource was not found on the server." });
        
        return Ok(product);
    }
}