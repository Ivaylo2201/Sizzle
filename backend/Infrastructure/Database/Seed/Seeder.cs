using Core.Interfaces.Repositories;

namespace Infrastructure.Database.Seed;

public class Seeder(DatabaseContext context, IUserRepository userRepository)
{
    public async Task Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Seeding database...");
        Console.ResetColor();
        
        await Clear();
        await Seed();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Seeding complete.");
        Console.ResetColor();
    }

    private async Task Clear()
    {
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

        foreach (var user in Data.Users)
        {
            await userRepository.Create(user);
        }
        
        await context.SaveChangesAsync();
    }
}