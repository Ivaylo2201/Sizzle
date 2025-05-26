using Backend.Database.Entities;
using Backend.DTOs.Item;

namespace Backend.Mappers;

public class ItemMapper
{
    public static ItemDto ToDto(Item item)
    {
        return new ItemDto
        {
            ProductName = item.Product.ProductName,
            Quantity = item.Quantity,
        };
    }
}