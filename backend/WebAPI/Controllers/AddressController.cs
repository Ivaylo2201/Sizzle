﻿using Application.CQRS.Addresses.Commands;
using Application.CQRS.Addresses.Queries;
using Application.DTOs.Address;
using Application.Extensions;
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
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAddressesAsync()
    {
        var addressResult = await mediator.Send(new ListAddressesQuery(User.GetId()));
        var response = addressResult.Value.Select(a => a.ToDto()).ToList();
        
        return Ok(response);
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddAddressAsync([FromBody] AddAddressRequest request)
    {
        var createAddressDto = new CreateAddressDto
        {
            StreetName = request.StreetName,
            StreetNumber = request.StreetNumber,
            CityId = request.CityId,
            UserId = User.GetId()
        };

        var addressResult = await mediator.Send(new CreateAddressCommand(createAddressDto));

        if (!addressResult.IsSuccess)
            return BadRequest(addressResult.ErrorObject);
        
        return Created(string.Empty, new { message = "Address added successfully." });
    }

    [Authorize]
    [HttpDelete("remove/{id:int}")]
    public async Task<IActionResult> RemoveAddressAsync([FromRoute] int id)
    {
        var addressResult = await mediator.Send(new GetAddressQuery(id));
        
        if (!addressResult.IsSuccess)
            return NotFound(addressResult.ErrorObject);
        
        if (!await ownershipService.HasAddressOwnershipAsync(addressResult.Value.Id, User.GetId()))
            return Forbid();
        
        await mediator.Send(new DeleteAddressCommand(addressResult.Value.Id));
        return NoContent();
    }
}