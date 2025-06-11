using Application.CQRS.Reviews.Commands;
using Application.DTOs.Review;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddReview([FromBody] CreateReviewRequest request)
    {
        var dto = new CreateReviewDto
        {
            Rating = request.Rating,
            Comment = request.Comment,
            ProductId = request.ProductId,
            UserId = User.GetId()
        };
        
        await mediator.Send(new CreateReviewCommand(dto));
        return Created(null as string, new { message = "Review added successfully." });
    }
}