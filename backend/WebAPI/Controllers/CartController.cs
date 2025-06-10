using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.DTOs.Item;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/carts")]
public class CartController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost("add-item")]
    public async Task<IActionResult> AddItemToCart([FromBody] CreateItemDto dto)
    {
        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));
        
        if (!cartResult.IsSuccess || cartResult.Value is null)
            return NotFound(new { message = cartResult.Error });
        
        dto.CartId = cartResult.Value.Id;
        await mediator.Send(new CreateItemCommand(dto));

        return Created(string.Empty, new { message = "Item added successfully." });
    }
}