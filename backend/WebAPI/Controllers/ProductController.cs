using Application.CQRS.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("{category}")]
    public async Task<IActionResult> ListAllProductsByCategory([FromRoute] string category)
    {
        var result = await mediator.Send(new ListProductsQuery(category));
        return Ok(result.Value);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetProductQuery(id));

        if (!result.IsSuccess)
            return NotFound(new { message = result.Error });
        
        return Ok(result.Value);
    }
}