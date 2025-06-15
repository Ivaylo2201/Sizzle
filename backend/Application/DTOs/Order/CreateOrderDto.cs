namespace Application.DTOs.Order;

public record CreateOrderDto
{
    public required Core.Entities.User User { get; init; }
    public required Core.Entities.Address Address { get; init; }
}