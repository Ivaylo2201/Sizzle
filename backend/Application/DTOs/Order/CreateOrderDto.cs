namespace Application.DTOs.Order;

public record CreateOrderDto
{
    public required Core.Entities.User User { get; init; }
}