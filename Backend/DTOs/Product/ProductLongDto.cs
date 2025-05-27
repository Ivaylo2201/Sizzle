using Backend.DTOs.Review;

namespace Backend.DTOs.Product;

public record ProductLongDto : ProductShortDto
{
    public required string Description { get; init; }
    public required int Calories { get; init; }
    public required string Category { get; init; }
    public required List<ReviewDto> Reviews { get; init; }
    public required List<string> Ingredients { get; init; }
}