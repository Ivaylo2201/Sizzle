namespace Application.DTOs.Item;

public record CreateItemDto
{
    public required Guid ProductId { get; init; }
    public int Quantity { get; set; } = 1;
    public int CartId { get; set; }
}