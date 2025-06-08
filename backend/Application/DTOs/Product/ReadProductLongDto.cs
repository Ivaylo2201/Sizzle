using Core.Entities;

namespace Application.DTOs.Product;

public class ReadProductLongDto : ReadProductShortDto
{
    public required int Calories { get; init; }
    public required int Weight { get; init; }
    public required string CategoryName { get; init; }
    public required List<Review> Reviews { get; init; } // TODO: CHANGE TO List<ReviewDto>
    public required List<string> Ingredients { get; init; }
}