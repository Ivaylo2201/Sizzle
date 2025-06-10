using Application.CQRS.Carts.Queries;
using Application.CQRS.Items.Commands;
using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Core.Abstractions;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateItemQuantity([FromRoute] int id, [FromBody] UpdateItemRequest request)
    {
        var ownershipResult = await CheckItemOwnership(id, User.GetId());

        if (ownershipResult is { IsSuccess: false, Error: not null })
            return Forbid(ownershipResult.Error);
        
        var dto = new UpdateItemDto { Id = id, Quantity = request.Quantity };
        var result = await mediator.Send(new UpdateItemCommand(dto));
        
        return result.IsSuccess
            ? Ok(new { message = $"Item {id}'s quantity updated to {request.Quantity}" }) 
            : BadRequest(new { message = result.Error });
    }

    private async Task<Result> CheckItemOwnership(int itemId, int userId)
    {
        var itemResult = await mediator.Send(new GetItemQuery(itemId));

        if (!itemResult.IsSuccess || itemResult.Value is null)
            return Result.Failure(itemResult.Error);
        
        var cartResult = await mediator.Send(new GetCartQuery(userId));
        
        if (!cartResult.IsSuccess || cartResult.Value is null)
            return Result.Failure(cartResult.Error);

        return itemResult.Value.CartId == cartResult.Value.Id
            ? Result.Success()
            : Result.Failure($"Item #{itemId} is not owned by user #{userId}");
    }
}