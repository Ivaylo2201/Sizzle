namespace Application.DTOs.Order;

public record CreateOrderDto
{
    public required int UserId { get; init; }
    public required int AddressId { get; init; }
    public string? Notes { get; init; }
    public required DateTime DeliveryTime { get; init; }
}