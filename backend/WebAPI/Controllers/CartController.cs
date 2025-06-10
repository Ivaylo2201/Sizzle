using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.DTOs.Item;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/carts/items")]
public class CartController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request)
    {
        var result = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!result.IsSuccess || result.Value is null)
            return NotFound(new { message = result.Error });

        var dto = new CreateItemDto
        {
            ProductId = request.ProductId, 
            Quantity = request.Quantity, 
            CartId = result.Value.Id
        };
        
        await mediator.Send(new CreateItemCommand(dto));
        return Created(string.Empty, new { message = "Item added successfully." });
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveItemFromCart([FromRoute] int id)
    {
        var result = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!result.IsSuccess || result.Value is null)
            return NotFound(new { message = result.Error });

        var dto = new DeleteItemDto { Id = id, CartId = result.Value.Id };
        
        await mediator.Send(new DeleteItemCommand(dto));
        return NoContent();
    }
}