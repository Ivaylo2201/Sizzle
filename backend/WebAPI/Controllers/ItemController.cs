using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.DTOs.Item;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("cart/add")]
    [Authorize]
    public async Task<IActionResult> AddItemToCart([FromBody] Guid productId)
    {
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!cartResult.IsSuccess || cartResult.Value is null)
            return NotFound(new { message = cartResult.Error });

        var dto = new CreateItemDto
        {
            ProductId = productId,
            Quantity = 1,
            CartId = cartResult.Value.Id
        };
        
        var result = await mediator.Send(new CreateItemCommand(dto));
        return Ok(result.Value);
    }
}