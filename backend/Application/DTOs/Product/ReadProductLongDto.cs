using Application.DTOs.Review;

namespace Application.DTOs.Product;

public record ReadProductLongDto : ReadProductShortDto
{
    public required int Calories { get; init; }
    public required int Weight { get; init; }
    public required string CategoryName { get; init; }
    public required List<ReadReviewDto> Reviews { get; init; }
    public required List<string> Ingredients { get; init; }
}