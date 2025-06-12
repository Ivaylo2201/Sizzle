using Application.CQRS.Addresses.Commands;
using Application.CQRS.Addresses.Queries;
using Application.DTOs.Address;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/profile/addresses")]
public class AddressController(IMediator mediator, IOwnershipService ownershipService) : ControllerBase
{
    // [Authorize]
    // [HttpGet]
    // public async Task<IActionResult> GetAddresses()
    // {
    //     var addressResult = await mediator.Send(new ListAddressesQuery(User.GetId()));
    // }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressRequest request)
    {
        var dto = new CreateAddressDto
        {
            StreetName = request.StreetName,
            StreetNumber = request.StreetNumber,
            CityId = request.CityId,
            UserId = User.GetId()
        };

        var addressResult = await mediator.Send(new CreateAddressCommand(dto));

        if (!addressResult.IsSuccess)
            return BadRequest(addressResult.ErrorObject);
        
        return Created(string.Empty, new { message = "Address added successfully." });
    }

    [Authorize]
    [HttpDelete("remove/{id:int}")]
    public async Task<IActionResult> RemoveAddress([FromRoute] int id)
    {
        var address = await mediator.Send(new GetAddressQuery(id));
        
        if (!address.IsSuccess)
            return NotFound(address.ErrorObject);
        
        if (!await ownershipService.HasAddressOwnership(address.Value.Id, User.GetId()))
            return Forbid();
        
        await mediator.Send(new DeleteAddressCommand(address.Value.Id));
        return NoContent();
    }
}