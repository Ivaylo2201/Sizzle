using Backend.Database.Entities;
using Backend.DTOs.Item;

namespace Backend.Mappers;

public static class ItemMapper
{
    public static ItemDto ToDto(this Item item)
    {
        return new ItemDto
        {
            ProductName = item.Product.ProductName,
            Quantity = item.Quantity,
        };
    }
}