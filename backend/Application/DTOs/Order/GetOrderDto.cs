using Application.DTOs.Item;

namespace Application.DTOs.Order;

public record GetOrderDto
{
    public required int Id { get; init; }
    public required List<GetItemDto> Items { get; init; }
    public required DateTime CreatedAt { get; init; }
}