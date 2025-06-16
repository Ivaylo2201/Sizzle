using Application.DTOs.Item;

namespace Application.DTOs.Order;

public record GetOrderDto
{
    public required int Id { get; init; }
    public required List<GetItemDto> Items { get; init; }
    
    public required string CityName { get; init; }
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
    public required DateTime CreatedAt { get; init; }
}