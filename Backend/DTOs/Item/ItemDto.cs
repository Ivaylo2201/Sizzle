namespace Backend.DTOs.Item;

public record ItemDto
{
    public required string ProductName { get; init; }
    public required int Quantity { get; init; }
};