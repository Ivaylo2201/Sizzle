using Application.CQRS.Items.Commands;
using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController(IMediator mediator, IOwnershipService ownershipService) : ControllerBase
{
    [Authorize]
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateItemQuantity([FromRoute] int id, [FromBody] UpdateItemRequest request)
    {
        var item = await mediator.Send(new GetItemQuery(id));

        if (!item.IsSuccess)
            return NotFound(item.ErrorObject);

        if (!await ownershipService.HasItemOwnershipAsync(item.Value.CartId, User.GetId()))
            return Forbid();

        var dto = new UpdateItemDto
        {
            Item = item.Value,
            Quantity = request.Quantity
        };
        
        await mediator.Send(new UpdateItemCommand(dto));
        return Ok(new { message = "Item quantity successfully updated." });
    }
}