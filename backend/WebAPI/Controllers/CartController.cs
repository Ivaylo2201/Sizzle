using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.CQRS.Items.Queries;
using Application.CQRS.Products.Queries;
using Application.DTOs.Item;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/carts/items")]
public class CartController(IMediator mediator, IOwnershipService ownershipService) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCartContent()
    {
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!cartResult.IsSuccess || cartResult.Value is null)
            return NotFound(new { message = cartResult.Error });
        
        return Ok(new { cartResult.Value.Items, cartResult.Value.Total });
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request)
    {
        var productResult = await mediator.Send(new GetProductQuery(request.ProductId));
        
        if (!productResult.IsSuccess || productResult.Value is null)
            return NotFound(new { error = productResult.Error });
        
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));

        var dto = new CreateItemDto
        {
            ProductId = request.ProductId, 
            Quantity = request.Quantity, 
            CartId = cartResult.Value!.Id
        };
        
        await mediator.Send(new CreateItemCommand(dto));
        return Created(string.Empty, new { message = "Item added successfully." });
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveItemFromCart([FromRoute] int id)
    {
        var itemResult = await mediator.Send(new GetItemQuery(id));

        if (!itemResult.IsSuccess || itemResult.Value is null)
            return NotFound(new { error = itemResult.Error });

        if (!await ownershipService.HasItemOwnership(itemResult.Value.Id, User.GetId()))
            return Forbid();
        
        var dto = new DeleteItemDto { Id = itemResult.Value.Id };
        await mediator.Send(new DeleteItemCommand(dto));
        return NoContent();
    }
}