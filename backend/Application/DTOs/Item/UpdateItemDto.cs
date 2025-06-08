namespace Application.DTOs.Item;

public record UpdateItemDto
{
    public required int ItemId { get; init; }
    public required int Quantity { get; init; }
}
