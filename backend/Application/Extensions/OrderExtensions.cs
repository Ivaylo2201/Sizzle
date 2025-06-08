using Application.DTOs.Order;
using Core.Entities;

namespace Application.Extensions;

public static class OrderExtensions
{
    public static ReadOrderDto ToDto(this Order order)
    {
        return new ReadOrderDto
        {
            Items = order.Items.Select(i => i.ToDto()).ToList(),
            CreatedAt = order.CreatedAt,
        };
    }
}