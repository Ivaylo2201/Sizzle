using Application.DTOs.Item;

namespace Application.DTOs.Order;

public record ReadOrderDto
{
    public required List<ReadItemDto> Items { get; init; }
    public required DateTime CreatedAt { get; init; }
}