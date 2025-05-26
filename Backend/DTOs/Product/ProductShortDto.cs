namespace Backend.DTOs.Product;

public record ProductShortDto
{
    public required int Id { get; init; }
    public required string ProductName { get; init; }
    public required decimal Price { get; init; }
    public required int DiscountPercentage { get; init; }
    public required string ImageUrl { get; init; }
}