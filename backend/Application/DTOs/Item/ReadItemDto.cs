namespace Application.DTOs.Item;

public record ReadItemDto
{
    public required string ProductName { get; init; }
    public required string ImageUrl { get; init; }
    public required double Price { get; init; }
    public required int Quantity { get; init; }
}