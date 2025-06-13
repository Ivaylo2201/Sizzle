using Application.Interfaces.Services;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class CartService(ICartRepository cartRepository) : ICartService
{
    public async Task AddItemPriceToCartTotalAsync(double itemPrice, Cart cart)
    {
        cart.Total += itemPrice;
        await cartRepository.UpdateAsync(cart);
    }
}