using Application.CQRS.Cities.Queries;
using Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/cities")]
public class CityController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cityResult = await mediator.Send(new ListCitiesQuery());
        var response = cityResult.Value.Select(c => c.ToDto());
        return Ok(response);
    }
}