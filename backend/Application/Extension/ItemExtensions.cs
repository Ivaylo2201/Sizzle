using Application.DTOs.Item;
using Core.Entities;

namespace Application.Extension;

public static class ItemExtensions
{
    public static ItemDto ToDto(this Item item)
    {
        return new ItemDto
        {
            ProductName = item.Product.ProductName,
            ImageUrl = item.Product.ImageUrl,
            Price = item.Product.Price,
            Quantity = item.Quantity,
        };
    }
}