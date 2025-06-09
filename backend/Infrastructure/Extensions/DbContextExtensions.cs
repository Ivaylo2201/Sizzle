using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Database.Seed;

namespace Infrastructure.Extensions;

public static class DbContextExtensions
{
    public static async Task AddAddressesAsync(
        this DatabaseContext context,
        AddressRepository addressRepository)
    {
        foreach (var address in Data.Addresses)
        {
            address.City = await context.Cities.Random();
            address.User = await context.Users.Random();
            await addressRepository.Create(address);
        }
    }
    
    public static async Task AddReviewsAsync(
        this DatabaseContext context,
        ReviewRepository reviewRepository)
    {
        foreach (var review in Data.Reviews)
        {
            review.Product = await context.Products.Random();
            review.User = await context.Users.Random();
            await reviewRepository.Create(review);
        }
    }

    public static async Task AddUsersAsync(
        this DatabaseContext _, 
        UserRepository userRepository)
    {
        foreach (var user in Data.Users)
        {
            await userRepository.Create(user);
        }
    }
}