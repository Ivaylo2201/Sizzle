namespace Application.DTOs.Review;

public record CreateReviewDto
{
    public required int Rating { get; init; }
    public string? Comment { get; init; }
    public required Guid ProductId { get; init; }
    public int UserId { get; set; }
}