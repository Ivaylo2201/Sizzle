using Core.Entities;

namespace Application.Interfaces.Services;

public interface ICartService
{
    Task AddItemPriceToCartTotal(double itemPrice, Cart cart);
}