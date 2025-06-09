namespace Application.DTOs.Item;

public record CreateItemDto
{
    public required Guid ProductId { get; init; }
    public required int Quantity { get; init; }
    public required int CartId { get; init; }
}