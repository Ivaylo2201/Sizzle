using Backend.Database.Entities;

namespace Backend.Database;

public static class Seeder
{
    public static async Task Run(DatabaseContext context)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Seeding database...");
        
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
        var categories = new List<Category>
        {
            new() { Id = 1, CategoryName = "Burgers" },
            new() { Id = 2, CategoryName = "Doners" },
            new() { Id = 3, CategoryName = "Snacks" },
        };

        var products = new List<Product>
        {
            new()
            {
                Id = 1,
                ProductName = "Bacon Burger",
                InitialPrice = 7.99m,
                DiscountPercentage = 10,
                ImageUrl = "/Burgers/bacon_burger.png",
                Description =
                    "A rich, smoky delight featuring crispy bacon atop a juicy beef patty, melted cheddar, and a burst of flavor in every bite.",
                Calories = 750,
                CategoryId = 1,
            },
            new()
            {
                Id = 2,
                ProductName = "Applewood Burger",
                InitialPrice = 8.49m,
                ImageUrl = "/Burgers/applewood_burger.png",
                Description =
                    "Savor the deep, savory aroma of applewood-smoked bacon layered over flame-grilled beef, with caramelized onions adding a touch of sweetness.",
                Calories = 770,
                CategoryId = 1,
            },
            new()
            {
                Id = 3,
                ProductName = "Breakfast Burger",
                InitialPrice = 8.99m,
                DiscountPercentage = 15,
                ImageUrl = "/Burgers/breakfast_burger.png",
                Description =
                    "The ultimate morning indulgence—juicy beef, a fried egg, bacon, and hash browns all tucked inside a buttery bun.",
                Calories = 820,
                CategoryId = 1,
            },
            new()
            {
                Id = 4,
                ProductName = "Buffalo Burger",
                InitialPrice = 9.29m,
                ImageUrl = "/Burgers/buffalo_burger.png",
                Description =
                    "Bold and fiery, this burger brings heat with tangy buffalo sauce and cools it down with creamy blue cheese—perfectly balanced.",
                Calories = 780,
                CategoryId = 1,
            },
            new()
            {
                Id = 5,
                ProductName = "Chicken Burger",
                InitialPrice = 7.49m,
                DiscountPercentage = 20,
                ImageUrl = "/Burgers/chicken_burger.png",
                Description =
                    "Grilled to perfection, our chicken burger is tender, juicy, and refreshingly light, served on a toasted bun with crisp greens.",
                Calories = 690,
                CategoryId = 1,
            },
            new()
            {
                Id = 6,
                ProductName = "Classic Burger",
                InitialPrice = 6.99m,
                ImageUrl = "/Burgers/classic_burger.png",
                Description =
                    "Simple yet irresistible—a traditional beef burger made with love, nostalgia, and the perfect balance of flavors.",
                Calories = 710,
                CategoryId = 1,
            },
            new()
            {
                Id = 7,
                ProductName = "Cranberry Burger",
                InitialPrice = 8.79m,
                DiscountPercentage = 10,
                ImageUrl = "/Burgers/cranberry_burger.png",
                Description =
                    "A festive fusion of savory and sweet, this burger features tangy cranberry sauce paired with a juicy turkey patty and creamy brie.",
                Calories = 730,
                CategoryId = 1,
            },
            new()
            {
                Id = 8,
                ProductName = "Deluxe Burger",
                InitialPrice = 9.49m,
                ImageUrl = "/Burgers/deluxe_burger.png",
                Description =
                    "A beast of a burger—double patties, melted cheese, smoky bacon, and all the fixings piled high for the ultimate feast.",
                Calories = 880,
                CategoryId = 1,
            },
            new()
            {
                Id = 9,
                ProductName = "Fish Burger",
                InitialPrice = 7.29m,
                DiscountPercentage = 5,
                ImageUrl = "/Burgers/fish_burger.png",
                Description =
                    "Crispy on the outside, tender on the inside—our golden fish fillet burger is a refreshing dive into flavor.",
                Calories = 660,
                CategoryId = 1,
            },
            new()
            {
                Id = 10,
                ProductName = "Jalapeno Burger",
                InitialPrice = 8.59m,
                ImageUrl = "/Burgers/jalapeno_burger.png",
                Description =
                    "Spice lovers rejoice—this burger packs a punch with fiery jalapeños and bold chipotle mayo on a juicy beef patty.",
                Calories = 770,
                CategoryId = 1,
            },
            new()
            {
                Id = 11,
                ProductName = "Pulled Pork Burger",
                InitialPrice = 8.99m,
                DiscountPercentage = 25,
                ImageUrl = "/Burgers/pulled_pork_burger.png",
                Description =
                    "Sweet, smoky, and melt-in-your-mouth—slow-cooked pulled pork with tangy BBQ sauce creates the perfect messy masterpiece.",
                Calories = 790,
                CategoryId = 1,
            },
            new()
            {
                Id = 12,
                ProductName = "Veggie Burger",
                InitialPrice = 7.89m,
                ImageUrl = "/Burgers/veggie_burger.png",
                Description =
                    "Wholesome and hearty, our veggie burger delivers bold flavor and satisfying texture with every plant-based bite.",
                Calories = 640,
                CategoryId = 1,
            }
        };
        
        context.Categories.AddRange(categories);
        context.Products.AddRange(products);
        
        await context.SaveChangesAsync();
    }
}