namespace Application.DTOs.Item;

public record CreateItemDto
{
    public required Guid ProductId { get; init; }
    public int Quantity { get; init; } = 1;
    public required int CartId { get; set; }
}