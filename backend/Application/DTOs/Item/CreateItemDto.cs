namespace Application.DTOs.Item;

public record CreateItemDto
{
    public required Core.Entities.Product Product { get; init; }
    public required Core.Entities.Cart Cart { get; init; }
    public required int Quantity { get; init; }
}