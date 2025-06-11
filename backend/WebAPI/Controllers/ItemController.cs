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
        var itemResult = await mediator.Send(new GetItemQuery(id));

        if (!itemResult.IsSuccess || itemResult.Value is null)
            return NotFound(new { error = itemResult.Error });

        if (!await ownershipService.HasItemOwnership(itemResult.Value.Id, User.GetId()))
            return Forbid();
        
        var dto = new UpdateItemDto { Id = id, Quantity = request.Quantity };
        var result = await mediator.Send(new UpdateItemCommand(dto));
        
        return result.IsSuccess
            ? Ok(new { message = "Item quantity successfully updated." }) 
            : BadRequest(new { message = result.Error });
    }
}