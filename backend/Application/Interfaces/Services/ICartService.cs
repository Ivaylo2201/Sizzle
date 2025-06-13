using Core.Entities;

namespace Application.Interfaces.Services;

public interface ICartService
{
    Task AddItemPriceToCartTotalAsync(double itemPrice, Cart cart);
}