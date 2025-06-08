using Core.Interfaces.Repositories;

namespace Infrastructure.Database.Seed;

internal static class ColorConsole
{
    public static void WriteLine(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public class Seeder(DatabaseContext context, IUserRepository userRepository)
{
    public async Task Run()
    {
        ColorConsole.WriteLine(ConsoleColor.Green, "Seeding database...");
        
        await Clear();
        await Seed();
        
        ColorConsole.WriteLine(ConsoleColor.Green, "Seeding complete.");
    }

    private async Task Clear()
    {
        ColorConsole.WriteLine(ConsoleColor.Red, "Truncating tables...");
        
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