namespace Backend.DTOs.Review;

public record ReviewDto
{
    public required string User { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required string? Comment { get; init; }
    public required int Rating { get; init; }
}