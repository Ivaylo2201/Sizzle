using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.CQRS.Items.Queries;
using Application.CQRS.Products.Queries;
using Application.DTOs.Item;
using Application.Extensions;
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
    public async Task<IActionResult> ListCartItemsAsync()
    {
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!cartResult.IsSuccess)
            return NotFound(cartResult.ErrorObject);

        var responseObject = new
        {
            items = cartResult.Value.Items.Select(i => i.ToDto()).ToList(),
            total = cartResult.Value.Total
        };

        return Ok(responseObject);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddItemToCartAsync([FromBody] AddItemToCartRequest request)
    {
        var productResult = await mediator.Send(new GetProductQuery(request.ProductId));
        
        if (!productResult.IsSuccess)
            return NotFound(productResult.ErrorObject);
        
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));

        var createItemDto = new CreateItemDto
        {
            Product = productResult.Value,
            Quantity = request.Quantity, 
            Cart = cartResult.Value
        };
        
        await mediator.Send(new CreateItemCommand(createItemDto));
        return Created(string.Empty, new { message = $"{productResult.Value.ProductName} added to cart!" });
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveItemFromCartAsync([FromRoute] int id)
    {
        var itemResult = await mediator.Send(new GetItemQuery(id));

        if (!itemResult.IsSuccess)
            return NotFound(itemResult.ErrorObject);

        if (!await ownershipService.HasItemOwnershipAsync(itemResult.Value.CartId, User.GetId())) 
            return Forbid();
        
        await mediator.Send(new DeleteItemCommand(itemResult.Value.Id));
        return NoContent();
    }
}