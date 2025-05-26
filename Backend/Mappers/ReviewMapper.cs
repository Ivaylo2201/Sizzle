using Backend.Database.Entities;
using Backend.DTOs.Review;

namespace Backend.Mappers;

public static class ReviewMapper
{
    public static ReviewDto ToDto(this Review review)
    {
        return new ReviewDto
        {
            User = $"{review.User.FirstName} {review.User.LastName}",
            CreatedAt = review.CreatedAt,
            Comment = review.Comment,
            Rating = review.Rating,
        };
    }
}