using Infrastructure.Database.Repositories;
using Infrastructure.Extensions;
using Infrastructure.Utilities;

namespace Infrastructure.Database.Seed;

public class Seeder(DatabaseContext context)
{
    private readonly UserRepository _userRepository = new(context);
    private readonly ReviewRepository _reviewRepository = new(context);
    private readonly AddressRepository _addressRepository = new(context);
    
    public async Task Run()
    {
        ColorConsole.WriteLine("Seeding database...");
        
        await Clear();
        await Seed();
        
        ColorConsole.WriteLine("Seeding complete.");
    }

    private async Task Clear()
    {
        ColorConsole.WriteLine("Truncating tables...", ConsoleColor.Red);
        
        context.Addresses.RemoveRange(context.Addresses);
        context.Cities.RemoveRange(context.Cities);
        context.Items.RemoveRange(context.Items);
        context.Orders.RemoveRange(context.Orders);
        context.Carts.RemoveRange(context.Carts);
        context.Reviews.RemoveRange(context.Reviews);
        context.Users.RemoveRange(context.Users);
        context.Products.RemoveRange(context.Products);
        context.Categories.RemoveRange(context.Categories);
        context.Ingredients.RemoveRange(context.Ingredients);
        
        await context.SaveChangesAsync();
    }

    private async Task Seed()
    {
        context.Categories.AddRange(Data.Categories.Values);
        context.Ingredients.AddRange(Data.Ingredients.Values);
        context.Products.AddRange(Data.Products);
        context.Cities.AddRange(Data.Cities);
        await context.AddUsersAsync(_userRepository);
        await context.AddAddressesAsync(_addressRepository);
        await context.AddReviewsAsync(_reviewRepository);
        
        await context.SaveChangesAsync();
    }
}