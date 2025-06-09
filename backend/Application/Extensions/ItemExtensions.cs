using Application.DTOs.Item;
using Core.Entities;

namespace Application.Extensions;

public static class ItemExtensions
{
    public static ReadItemDto ToDto(this Item item)
    {
        return new ReadItemDto
        {
            Id = item.Id,
            ProductName = item.Product.ProductName,
            ImageUrl = item.Product.ImageUrl,
            Price = item.Product.Price,
            Quantity = item.Quantity,
        };
    }
}