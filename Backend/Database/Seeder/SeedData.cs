using Backend.Database.Entities;

namespace Backend.Database.Seeder;

public static class SeedData
{
    public static readonly Dictionary<string, Ingredient> Ingredients = new()
    {
        { "buffaloBeef", new Ingredient { Id = 1, IngredientName = "Buffalo beef" } },
        { "cheddarCheese", new Ingredient { Id = 2, IngredientName = "Cheddar cheese" } },
        { "lettuce", new Ingredient { Id = 3, IngredientName = "Lettuce" } },
        { "tomato", new Ingredient { Id = 4, IngredientName = "Tomato" } },
        { "caramelizedOnions", new Ingredient { Id = 5, IngredientName = "Caramelized onions" } },
        { "pickles", new Ingredient { Id = 6, IngredientName = "Pickles" } },
        { "bbqSauce", new Ingredient { Id = 7, IngredientName = "BBQ sauce" } },
        { "briocheBun", new Ingredient { Id = 8, IngredientName = "Brioche bun" } },
        { "pulledPork", new Ingredient { Id = 9, IngredientName = "Pulled pork" } },
        { "coleslaw", new Ingredient { Id = 10, IngredientName = "Coleslaw" } },
        { "beefPatty", new Ingredient { Id = 11, IngredientName = "Beef patty" } },
        { "friedEgg", new Ingredient { Id = 12, IngredientName = "Fried egg" } },
        { "mayonnaise", new Ingredient { Id = 13, IngredientName = "Mayonnaise" } },
        { "sesameBun", new Ingredient { Id = 14, IngredientName = "Sesame bun" } },
        { "blackBeanPatty", new Ingredient { Id = 15, IngredientName = "Black bean patty" } },
        { "avocado", new Ingredient { Id = 16, IngredientName = "Avocado" } },
        { "hummus", new Ingredient { Id = 17, IngredientName = "Hummus" } },
        { "wholeGrainBun", new Ingredient { Id = 18, IngredientName = "Whole grain bun" } },
        { "smokedApplewoodCheddar", new Ingredient { Id = 19, IngredientName = "Smoked applewood cheddar" } },
        { "crispyBacon", new Ingredient { Id = 20, IngredientName = "Crispy bacon" } },
        { "crispyChickenFillet", new Ingredient { Id = 21, IngredientName = "Crispy chicken fillet" } },
        { "ketchup", new Ingredient { Id = 22, IngredientName = "Ketchup" } },
        { "mustard", new Ingredient { Id = 23, IngredientName = "Mustard" } },
        { "jalapeno", new Ingredient { Id = 24, IngredientName = "Jalapeños" } },
        { "fishFillet", new Ingredient { Id = 25, IngredientName = "Fish fillet" } },
        { "cranberrySauce", new Ingredient { Id = 26, IngredientName = "Cranberry sauce" } },
        { "brieCheese", new Ingredient { Id = 27, IngredientName = "Brie cheese" } }
    };

    public static readonly List<Category> Categories = 
    [
        new() { Id = 1, CategoryName = "Burgers" },
        new() { Id = 2, CategoryName = "Doners" },
        new() { Id = 3, CategoryName = "Snacks" }
    ];

    public static readonly List<Product> Products =
    [
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"], Ingredients["crispyBacon"], Ingredients["cheddarCheese"],
                    Ingredients["pickles"], Ingredients["mayonnaise"], Ingredients["sesameBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"], Ingredients["smokedApplewoodCheddar"], Ingredients["crispyBacon"],
                    Ingredients["caramelizedOnions"], Ingredients["lettuce"], Ingredients["tomato"],
                    Ingredients["bbqSauce"], Ingredients["briocheBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"],
                    Ingredients["friedEgg"],
                    Ingredients["cheddarCheese"],
                    Ingredients["lettuce"],
                    Ingredients["tomato"],
                    Ingredients["pickles"],
                    Ingredients["mayonnaise"],
                    Ingredients["sesameBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["buffaloBeef"],
                    Ingredients["cheddarCheese"],
                    Ingredients["lettuce"],
                    Ingredients["tomato"],
                    Ingredients["caramelizedOnions"],
                    Ingredients["pickles"],
                    Ingredients["bbqSauce"],
                    Ingredients["briocheBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"],
                    Ingredients["crispyChickenFillet"],
                    Ingredients["lettuce"],
                    Ingredients["tomato"],
                    Ingredients["pickles"],
                    Ingredients["mayonnaise"],
                    Ingredients["cheddarCheese"],
                    Ingredients["briocheBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"],
                    Ingredients["cheddarCheese"],
                    Ingredients["caramelizedOnions"],
                    Ingredients["ketchup"],
                    Ingredients["mustard"],
                    Ingredients["briocheBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"],
                    Ingredients["cranberrySauce"],
                    Ingredients["brieCheese"],
                    Ingredients["lettuce"],
                    Ingredients["caramelizedOnions"],
                    Ingredients["briocheBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"],
                    Ingredients["friedEgg"],
                    Ingredients["crispyBacon"],
                    Ingredients["cheddarCheese"],
                    Ingredients["pickles"],
                    Ingredients["mayonnaise"],
                    Ingredients["briocheBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["fishFillet"],
                    Ingredients["lettuce"],
                    Ingredients["tomato"],
                    Ingredients["caramelizedOnions"],
                    Ingredients["cheddarCheese"],
                    Ingredients["sesameBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["beefPatty"],
                    Ingredients["jalapeno"],
                    Ingredients["cheddarCheese"],
                    Ingredients["lettuce"],
                    Ingredients["tomato"],
                    Ingredients["pickles"],
                    Ingredients["mayonnaise"],
                    Ingredients["sesameBun"]
                }
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
                Ingredients = new List<Ingredient>
                {
                    Ingredients["pulledPork"],
                    Ingredients["coleslaw"],
                    Ingredients["pickles"],
                    Ingredients["bbqSauce"],
                    Ingredients["briocheBun"]
                }
            },
            new()
            {
                Id = 12,
                ProductName = "Veggie Burger",
                InitialPrice = 7.89m,
                ImageUrl = "/Burgers/veggie_burger.png",
                Description =
                    "A garden-fresh delight, packed with a hearty plant-based patty and crisp veggies, perfect for a healthy bite.",
                Calories = 680,
                CategoryId = 1,
                Ingredients = new List<Ingredient>
                {
                    Ingredients["blackBeanPatty"],
                    Ingredients["avocado"],
                    Ingredients["lettuce"],
                    Ingredients["tomato"],
                    Ingredients["caramelizedOnions"],
                    Ingredients["pickles"],
                    Ingredients["hummus"],
                    Ingredients["wholeGrainBun"]
                }
            }
    ];
}