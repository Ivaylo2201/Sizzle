using Application.DTOs.Review;
using Core.Entities;

namespace Application.Extensions;

public static class ReviewExtensions
{
    public static GetReviewDto ToDto(this Review review)
    {
        return new GetReviewDto
        {
            Id = review.Id,
            Rating = review.Rating,
            Comment = review.Comment,
            Username = review.User.Username,
            CreatedAt = review.CreatedAt,
        };
    }
}