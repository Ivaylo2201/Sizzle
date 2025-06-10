using Application.CQRS.Reviews.Commands;
using Application.DTOs.Review;
using Application.Extensions;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("add")]
    [Authorize]
    public async Task<IActionResult> AddReview([FromBody] CreateReviewDto dto)
    {
        dto.UserId = User.GetId();
        await mediator.Send(new CreateReviewCommand(dto));
        return Created(null as string, new { message = "Item added successfully." });
    }
}