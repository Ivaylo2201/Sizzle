namespace Application.DTOs.Item;

public record UpdateItemDto
{
    public required Core.Entities.Item Item { get; init; }
    public required int Quantity { get; init; }
}
