namespace Application.DTOs.Item;

public record DeleteItemDto
{
    public required int Id { get; init; }
    public required int CartId { get; init; }
}
