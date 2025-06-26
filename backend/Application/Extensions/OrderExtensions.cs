using Application.DTOs.Order;
using Core.Entities;

namespace Application.Extensions;

public static class OrderExtensions
{
    public static GetOrderDto ToDto(this Order order)
    {
        return new GetOrderDto
        {
            Id = order.Id,
            CityName = order.Address.City.CityName,
            StreetName = order.Address.StreetName,
            StreetNumber = order.Address.StreetNumber,
            Items = order.Items.Select(i => i.ToDto()).ToList(),
            Total = order.Items.Sum(i => i.Price),
            CreatedAt = order.CreatedAt,
            Notes = order.Notes
        };
    }
}