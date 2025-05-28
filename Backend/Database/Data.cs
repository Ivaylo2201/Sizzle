using Backend.Database.Entities;

namespace Backend.Database;

public static class Data
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
        { "brieCheese", new Ingredient { Id = 27, IngredientName = "Brie cheese" } },
        { "grilledChicken", new Ingredient { Id = 28, IngredientName = "Grilled chicken" } },
        { "grilledLamb", new Ingredient { Id = 29, IngredientName = "Grilled lamb" } },
        { "donerWrap", new Ingredient { Id = 30, IngredientName = "Doner wrap" } },
        { "pitaBread", new Ingredient { Id = 31, IngredientName = "Pita bread" } },
        { "lavash", new Ingredient { Id = 32, IngredientName = "Lavash" } },
        { "garlicSauce", new Ingredient { Id = 33, IngredientName = "Garlic sauce" } },
        { "chiliSauce", new Ingredient { Id = 34, IngredientName = "Chili sauce" } },
        { "yogurtSauce", new Ingredient { Id = 35, IngredientName = "Yogurt sauce" } },
        { "redCabbage", new Ingredient { Id = 36, IngredientName = "Red cabbage" } },
        { "cucumber", new Ingredient { Id = 37, IngredientName = "Cucumber" } },
        { "rawOnion", new Ingredient { Id = 38, IngredientName = "Raw onion" } },
        { "parsley", new Ingredient { Id = 39, IngredientName = "Parsley" } },
        { "frenchFries", new Ingredient { Id = 40, IngredientName = "French fries" } },
        { "tomatoSauce", new Ingredient { Id = 41, IngredientName = "Tomato sauce" } },
        { "pickledPeppers", new Ingredient { Id = 42, IngredientName = "Pickled peppers" } },
        { "olives", new Ingredient { Id = 43, IngredientName = "Olives" } },
        { "rice", new Ingredient { Id = 44, IngredientName = "Rice" } },
        { "mozzarella", new Ingredient { Id = 45, IngredientName = "Mozzarella" } },
        { "tortillaChips", new Ingredient { Id = 46, IngredientName = "Tortilla chips" } },
        { "sourCream", new Ingredient { Id = 47, IngredientName = "Sour cream" } },
        { "salsa", new Ingredient { Id = 48, IngredientName = "Salsa" } },
        { "falafelMix", new Ingredient { Id = 49, IngredientName = "Falafel mix" } },
        { "breadcrumbs", new Ingredient { Id = 50, IngredientName = "Breadcrumbs" } },
        { "potatoes", new Ingredient { Id = 51, IngredientName = "Potatoes" } },
        { "batteringMix", new Ingredient { Id = 52, IngredientName = "Battering mix" } },
        { "cheddarCheeseSauce", new Ingredient { Id = 53, IngredientName = "Cheddar cheese sauce" } },
        { "eggs", new Ingredient { Id = 54, IngredientName = "Eggs" } },
        { "sunflowerOil", new Ingredient { Id = 55, IngredientName = "Sunflower oil" } },
        { "salt", new Ingredient { Id = 56, IngredientName = "Salt" } },
        { "sugar", new Ingredient { Id = 57, IngredientName = "Sugar" } }
    };

    public static readonly Dictionary<string, Category> Categories = new()
    {
        {"burgers", new Category { Id = 1, CategoryName = "Burgers" } },
        {"doners", new Category { Id = 2, CategoryName = "Doners" } },
        {"snacks",  new Category { Id = 3, CategoryName = "Snacks" } }
    };

    public static readonly List<Product> Products =
    [
        new()
        {
            Id = 1,
            ProductName = "Bacon Burger",
            InitialPrice = 8,
            DiscountPercentage = 10,
            ImageUrl = "/Burgers/bacon_burger.png",
            Description =
                "A rich, smoky delight featuring crispy bacon atop a juicy beef patty, melted cheddar, and a burst of flavor in every bite.",
            Calories = 750,
            Weight = 250,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 10,
            ImageUrl = "/Burgers/applewood_burger.png",
            Description =
                "Savor the deep, savory aroma of applewood-smoked bacon layered over flame-grilled beef, with caramelized onions adding a touch of sweetness.",
            Calories = 770,
            Weight = 280,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 10,
            DiscountPercentage = 15,
            ImageUrl = "/Burgers/breakfast_burger.png",
            Description =
                "The ultimate morning indulgence—juicy beef, a fried egg, bacon, and hash browns all tucked inside a buttery bun.",
            Calories = 820,
            Weight = 320,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 12,
            ImageUrl = "/Burgers/buffalo_burger.png",
            Description =
                "Bold and fiery, this burger brings heat with tangy buffalo sauce and cools it down with creamy blue cheese—perfectly balanced.",
            Calories = 780,
            Weight = 295,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 8,
            DiscountPercentage = 20,
            ImageUrl = "/Burgers/chicken_burger.png",
            Description =
                "Grilled to perfection, our chicken burger is tender, juicy, and refreshingly light, served on a toasted bun with crisp greens.",
            Calories = 690,
            Weight = 270,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 7,
            ImageUrl = "/Burgers/classic_burger.png",
            Description =
                "Simple yet irresistible—a traditional beef burger made with love, nostalgia, and the perfect balance of flavors.",
            Calories = 710,
            Weight = 260,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 9,
            DiscountPercentage = 10,
            ImageUrl = "/Burgers/cranberry_burger.png",
            Description =
                "A festive fusion of savory and sweet, this burger features tangy cranberry sauce paired with a juicy turkey patty and creamy brie.",
            Calories = 730,
            Weight = 275,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 10,
            ImageUrl = "/Burgers/deluxe_burger.png",
            Description =
                "A beast of a burger—double patties, melted cheese, smoky bacon, and all the fixings piled high for the ultimate feast.",
            Calories = 880,
            Weight = 350,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 8,
            DiscountPercentage = 5,
            ImageUrl = "/Burgers/fish_burger.png",
            Description =
                "Crispy on the outside, tender on the inside—our golden fish fillet burger is a refreshing dive into flavor.",
            Calories = 660,
            Weight = 240,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            ProductName = "Jalapeño Burger",
            InitialPrice = 10,
            ImageUrl = "/Burgers/jalapeno_burger.png",
            Description =
                "Spice lovers rejoice—this burger packs a punch with fiery jalapeños and bold chipotle mayo on a juicy beef patty.",
            Calories = 770,
            Weight = 285,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 9,
            DiscountPercentage = 25,
            ImageUrl = "/Burgers/pulled_pork_burger.png",
            Description =
                "Sweet, smoky, and melt-in-your-mouth—slow-cooked pulled pork with tangy BBQ sauce creates the perfect messy masterpiece.",
            Calories = 790,
            Weight = 310,
            CategoryId = 1,
            Category = Categories["burgers"],
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
            InitialPrice = 8,
            ImageUrl = "/Burgers/veggie_burger.png",
            Description =
                "A garden-fresh delight, packed with a hearty plant-based patty and crisp veggies, perfect for a healthy bite.",
            Calories = 680,
            Weight = 265,
            CategoryId = 1,
            Category = Categories["burgers"],
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
        },
        new()
        {
            Id = 13,
            ProductName = "Beef Doner",
            InitialPrice = 9,
            ImageUrl = "/Doners/beef_doner.png",
            Description =
                "Tender slices of seasoned buffalo beef, layered in a warm pita with crisp veggies and garlic sauce.",
            Calories = 780,
            Weight = 320,
            CategoryId = 2,
            Category = Categories["doners"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["buffaloBeef"],
                Ingredients["pitaBread"],
                Ingredients["lettuce"],
                Ingredients["tomato"],
                Ingredients["redCabbage"],
                Ingredients["rawOnion"],
                Ingredients["garlicSauce"]
            }
        },
        new()
        {
            Id = 14,
            ProductName = "Chicken Doner",
            InitialPrice = 8,
            ImageUrl = "/Doners/chicken_doner.png",
            Description =
                "Juicy grilled chicken wrapped in lavash with fresh vegetables and creamy yogurt sauce.",
            Calories = 730,
            Weight = 310,
            CategoryId = 2,
            Category = Categories["doners"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["grilledChicken"],
                Ingredients["lavash"],
                Ingredients["cucumber"],
                Ingredients["redCabbage"],
                Ingredients["rawOnion"],
                Ingredients["yogurtSauce"]
            }
        },
        new()
        {
            Id = 15,
            ProductName = "Crispy Chicken Doner",
            InitialPrice = 9,
            ImageUrl = "/Doners/crispy_chicken_doner.png",
            Description =
                "Golden crispy chicken fillet in a pita, balanced with fresh lettuce and tangy chili sauce.",
            Calories = 810,
            Weight = 330,
            CategoryId = 2,
            Category = Categories["doners"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["crispyChickenFillet"],
                Ingredients["pitaBread"],
                Ingredients["lettuce"],
                Ingredients["pickles"],
                Ingredients["chiliSauce"],
                Ingredients["mayonnaise"]
            }
        },
        new()
        {
            Id = 16,
            ProductName = "Lamb Doner",
            InitialPrice = 10,
            ImageUrl = "/Doners/lamb_doner.png",
            Description =
                "Authentic grilled lamb with parsley and veggies, wrapped in soft lavash and topped with garlic sauce.",
            Calories = 820,
            Weight = 340,
            CategoryId = 2,
            Category = Categories["doners"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["grilledLamb"],
                Ingredients["lavash"],
                Ingredients["parsley"],
                Ingredients["redCabbage"],
                Ingredients["rawOnion"],
                Ingredients["garlicSauce"]
            }
        },
        new()
        {
            Id = 17,
            ProductName = "Pork Doner",
            InitialPrice = 8,
            ImageUrl = "/Doners/pork_doner.png",
            Description =
                "Savory pulled pork wrapped in pita with coleslaw and BBQ sauce for that sweet smoky flavor.",
            Calories = 790,
            Weight = 325,
            CategoryId = 2,
            Category = Categories["doners"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["pulledPork"],
                Ingredients["pitaBread"],
                Ingredients["coleslaw"],
                Ingredients["bbqSauce"]
            }
        },
        new()
        {
            Id = 18,
            ProductName = "Spicy Pork Doner",
            InitialPrice = 9,
            ImageUrl = "/Doners/spicy_pork_doner.png",
            Description =
                "Bold and fiery pork doner with jalapeños and chili sauce, wrapped in lavash for spice lovers.",
            Calories = 820,
            Weight = 335,
            CategoryId = 2,
            Category = Categories["doners"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["pulledPork"],
                Ingredients["lavash"],
                Ingredients["jalapeno"],
                Ingredients["chiliSauce"],
                Ingredients["pickledPeppers"]
            }
        },
        new()
        {
            Id = 19,
            ProductName = "Cheese Balls",
            InitialPrice = 4,
            ImageUrl = "/Snacks/cheese_balls.png",
            Description = "Crispy golden balls with a gooey cheddar cheese center — the ultimate snack-time treat.",
            Calories = 450,
            Weight = 150,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 20,
            Ingredients = new List<Ingredient>
            {
                Ingredients["cheddarCheese"],
                Ingredients["breadcrumbs"],
                Ingredients["batteringMix"]
            }
        },
        new()
        {
            Id = 20,
            ProductName = "Chicken Nuggets",
            InitialPrice = 5,
            ImageUrl = "/Snacks/chicken_nuggets.png",
            Description = "Tender, juicy chicken pieces coated in a crispy golden crust — snack perfection.",
            Calories = 520,
            Weight = 180,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 15,
            Ingredients = new List<Ingredient>
            {
                Ingredients["crispyChickenFillet"],
                Ingredients["batteringMix"],
                Ingredients["breadcrumbs"]
            }
        },
        new()
        {
            Id = 21,
            ProductName = "Falafels",
            InitialPrice = 4,
            ImageUrl = "/Snacks/falafels.png",
            Description = "Middle Eastern spiced chickpea balls — crispy outside, soft and flavorful inside.",
            Calories = 390,
            Weight = 160,
            CategoryId = 3,
            Category = Categories["snacks"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["falafelMix"],
                Ingredients["batteringMix"]
            }
        },
        new()
        {
            Id = 22,
            ProductName = "Big french fries",
            InitialPrice = 3,
            ImageUrl = "/Snacks/french_fries_big.png",
            Description = "A generous serving of classic golden fries — crispy, salty, and satisfying.",
            Calories = 600,
            Weight = 250,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 25,
            Ingredients = new List<Ingredient>
            {
                Ingredients["potatoes"]
            }
        },
        new()
        {
            Id = 23,
            ProductName = "Medium french fries",
            InitialPrice = 2.5m,
            ImageUrl = "/Snacks/french_fries_medium.png",
            Description = "Perfectly portioned crispy fries, golden and irresistible.",
            Calories = 450,
            Weight = 180,
            CategoryId = 3,
            Category = Categories["snacks"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["potatoes"]
            }
        },
        new()
        {
            Id = 24,
            ProductName = "Small french fries",
            InitialPrice = 2,
            ImageUrl = "/Snacks/french_fries_small.png",
            Description = "Small size, same big fry flavor — crispy and golden.",
            Calories = 300,
            Weight = 120,
            CategoryId = 3,
            Category = Categories["snacks"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["potatoes"]
            }
        },
        new()
        {
            Id = 25,
            ProductName = "Ketchup",
            InitialPrice = 0.5m,
            ImageUrl = "/Snacks/ketchup.png",
            Description = "Classic tomato ketchup — a tangy companion for your snacks.",
            Calories = 80,
            Weight = 50,
            CategoryId = 3,
            Category = Categories["snacks"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["tomato"],
                Ingredients["salt"],
                Ingredients["sugar"]
            }
        },
        new()
        {
            Id = 26,
            ProductName = "Mayonnaise",
            InitialPrice = 0.5m,
            ImageUrl = "/Snacks/mayonnaise.png",
            Description = "Creamy and smooth — the perfect dip for any snack.",
            Calories = 120,
            Weight = 50,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 10,
            Ingredients = new List<Ingredient>
            {
                Ingredients["eggs"],
                Ingredients["sunflowerOil"],
                Ingredients["salt"]
            }
        },
        new()
        {
            Id = 27,
            ProductName = "Mozzarella Sticks",
            InitialPrice = 4.5m,
            ImageUrl = "/Snacks/mozzarella_sticks.png",
            Description = "Crunchy on the outside, melty mozzarella on the inside — a cheese lover’s dream.",
            Calories = 470,
            Weight = 160,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 30,
            Ingredients = new List<Ingredient>
            {
                Ingredients["mozzarella"],
                Ingredients["breadcrumbs"],
                Ingredients["batteringMix"]
            }
        },
        new()
        {
            Id = 28,
            ProductName = "Nachos",
            InitialPrice = 5,
            ImageUrl = "/Snacks/nachos.png",
            Description = "Crispy tortilla chips served with creamy cheddar sauce and fresh salsa.",
            Calories = 520,
            Weight = 200,
            CategoryId = 3,
            Category = Categories["snacks"],
            Ingredients = new List<Ingredient>
            {
                Ingredients["tortillaChips"],
                Ingredients["cheddarCheeseSauce"],
                Ingredients["salsa"]
            }
        },
        new()
        {
            Id = 29,
            ProductName = "Onion Rings",
            InitialPrice = 4,
            ImageUrl = "/Snacks/onion_rings.png",
            Description = "Golden-fried onion rings — crispy, savory, and endlessly snackable.",
            Calories = 430,
            Weight = 170,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 50,
            Ingredients = new List<Ingredient>
            {
                Ingredients["caramelizedOnions"],
                Ingredients["batteringMix"],
                Ingredients["breadcrumbs"]
            }
        }
    ];
}