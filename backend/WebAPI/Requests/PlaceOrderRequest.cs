namespace WebAPI.Requests;

public record PlaceOrderRequest
{
    public required int AddressId { get; init; }
    public required string DeliveryTime { get; init; }
    public string? Notes { get; init; }
}