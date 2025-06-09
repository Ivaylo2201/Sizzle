using Application.DTOs.Order;
using Core.Entities;

namespace Application.Extensions;

public static class OrderExtensions
{
    public static GetOrderDto ToDto(this Order order)
    {
        return new GetOrderDto
        {
            Items = order.Items.Select(i => i.ToDto()).ToList(),
            CreatedAt = order.CreatedAt,
        };
    }
}