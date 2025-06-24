﻿using Application.CQRS.Addresses.Queries;
using Application.CQRS.Carts.Queries;
using Application.CQRS.Orders.Commands;
using Application.CQRS.Orders.Queries;
using Application.DTOs.Order;
using Application.Extensions;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var ordersResult = await mediator.Send(new ListOrdersQuery(User.GetId()));
        var response = ordersResult.Value.Select(o => o.ToDto()).ToList();
        return Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request)
    {
        var addressResult = await mediator.Send(new GetAddressQuery(request.AddressId));

        if (!addressResult.IsSuccess)
            return BadRequest(addressResult.ErrorObject);

        var cartResult = await mediator.Send(new GetCartQuery(User.GetId()));

        if (!cartResult.IsSuccess)
            return BadRequest(cartResult.ErrorObject);

        if (cartResult.Value.Items.Count == 0)
            return BadRequest(new { message = "Your cart is empty." });
        
        var createOrderDto = new CreateOrderDto
        {
            UserId = User.GetId(),
            AddressId = request.AddressId,
            DeliveryTime = DateTime.Parse(request.DeliveryTime),
            Notes = request.Notes
        };

        var orderResult = await mediator.Send(new CreateOrderCommand(createOrderDto));

        if (!orderResult.IsSuccess)
            return BadRequest(orderResult.ErrorObject);
        
        return Created(string.Empty, new { message = $"Order #{orderResult.Value.Id} placed successfully" });
    }
}