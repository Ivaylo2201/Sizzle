using Application.CQRS.Orders.Queries;
using Application.Extensions;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
}