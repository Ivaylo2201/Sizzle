namespace Infrastructure.Database.Seed;

public static class Seeder
{
    public static async Task Run(DatabaseContext context)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Seeding database...");
        Console.ResetColor();
        
        await Clear(context);
        await Seed(context);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Seeding complete.");
        Console.ResetColor();
    }

    private static async Task Clear(DatabaseContext context)
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

    private static async Task Seed(DatabaseContext context)
    {
        context.Categories.AddRange(Data.Categories.Values);
        context.Ingredients.AddRange(Data.Ingredients.Values);
        context.Products.AddRange(Data.Products);
        
        await context.SaveChangesAsync();
    }
}