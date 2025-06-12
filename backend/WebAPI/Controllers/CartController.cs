using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.CQRS.Items.Queries;
using Application.CQRS.Products.Queries;
using Application.DTOs.Item;
using Application.Extensions;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using Infrastructure.Utilities;
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
        var cart = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!cart.IsSuccess)
            return NotFound(cart.ErrorObject);

        return Ok(new
        {
            items = cart.Value.Items.Select(i => i.ToDto()).ToList(),
            total = cart.Value.Total
        });
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request)
    {
        var product = await mediator.Send(new GetProductQuery(request.ProductId));
        
        if (!product.IsSuccess)
            return NotFound(product.ErrorObject);
        
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));

        var dto = new CreateItemDto
        {
            Product = product.Value,
            Quantity = request.Quantity, 
            Cart = cartResult.Value
        };
        
        await mediator.Send(new CreateItemCommand(dto));
        return Created(string.Empty, new { message = "Item added successfully." });
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveItemFromCart([FromRoute] int id)
    {
        var item = await mediator.Send(new GetItemQuery(id));

        if (!item.IsSuccess)
            return NotFound(item.ErrorObject);

        var hasOwnership = await ownershipService.HasItemOwnership(item.Value.CartId, User.GetId());
        Console.WriteLine(hasOwnership);

        if (!hasOwnership)
        {
            Console.WriteLine("XDXDDX");
            return Forbid();
        }

        Console.WriteLine("deleting...");
        await mediator.Send(new DeleteItemCommand(item.Value.Id));
        return NoContent();
    }
}