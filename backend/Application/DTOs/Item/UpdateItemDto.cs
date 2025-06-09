namespace Application.DTOs.Item;

public record UpdateItemDto
{
    public required int Id { get; init; }
    public required int Quantity { get; init; }
}
