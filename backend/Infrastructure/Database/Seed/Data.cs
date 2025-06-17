using Core.Entities;

namespace Infrastructure.Database.Seed;

public static class Data
{
    public static readonly List<User> Users =
    [
        new() { Username = "JohnDoe", PhoneNumber = "0888888888", Password = "SecurePassword123" },
        new() { Username = "JaneDoe", PhoneNumber = "0999999999", Password = "456PasswordSecure" }
    ];

    public static readonly List<City> Cities =
    [
        new() { CityName = "Sofia" },
        new() { CityName = "Plovdiv" },
        new() { CityName = "Varna" },
        new() { CityName = "Burgas" },
        new() { CityName = "Ruse" }
    ];
    
    public static readonly List<Address> Addresses =
    [
        new() { StreetName = "Tsar Simeon Str.", StreetNumber = 14 },
        new() { StreetName = "Hristo Botev Blvd.", StreetNumber = 22 },
        new() { StreetName = "Vasil Levski Blvd.", StreetNumber = 5 },
        new() { StreetName = "Alexander Stamboliyski Blvd.", StreetNumber = 39 },
        new() { StreetName = "Patriarch Evtimiy Blvd.", StreetNumber = 11 },
        new() { StreetName = "Ivan Vazov Str.", StreetNumber = 7 },
        new() { StreetName = "Rakovski Str.", StreetNumber = 18 },
        new() { StreetName = "Slivnitsa Blvd.", StreetNumber = 27 },
        new() { StreetName = "Tsar Boris III Blvd.", StreetNumber = 36 },
        new() { StreetName = "Geo Milev Str.", StreetNumber = 9 }
    ];

    public static readonly List<Review> Reviews =
    [
        new() { Rating = 4, Comment = "Very delicious!" },
        new() { Rating = 5, Comment = "Absolutely amazing!" },
        new() { Rating = 3, Comment = "Pretty good, but could be better." },
        new() { Rating = 2, Comment = "Not my taste." },
        new() { Rating = 4, Comment = "Tasty and well prepared!" },
        new() { Rating = 5, Comment = "Best burger I've ever had!" },
        new() { Rating = 1, Comment = "Too salty and overcooked." },
        new() { Rating = 3, Comment = "It was okay." },
        new() { Rating = 4, Comment = "Would definitely order again." },
        new() { Rating = 5, Comment = "Perfect combo of flavor and texture!" },
        new() { Rating = 2, Comment = "Disappointed, expected more." }
    ];
    
    public static readonly Dictionary<string, Ingredient> Ingredients = new()
    {
        { "buffaloBeef", new Ingredient { IngredientName = "Buffalo beef" } },
        { "cheddarCheese", new Ingredient { IngredientName = "Cheddar cheese" } },
        { "lettuce", new Ingredient { IngredientName = "Lettuce" } },
        { "tomato", new Ingredient { IngredientName = "Tomato" } },
        { "caramelizedOnions", new Ingredient { IngredientName = "Caramelized onions" } },
        { "pickles", new Ingredient { IngredientName = "Pickles" } },
        { "bbqSauce", new Ingredient { IngredientName = "BBQ sauce" } },
        { "briocheBun", new Ingredient { IngredientName = "Brioche bun" } },
        { "pulledPork", new Ingredient { IngredientName = "Pulled pork" } },
        { "coleslaw", new Ingredient { IngredientName = "Coleslaw" } },
        { "beefPatty", new Ingredient { IngredientName = "Beef patty" } },
        { "friedEgg", new Ingredient { IngredientName = "Fried egg" } },
        { "mayonnaise", new Ingredient { IngredientName = "Mayonnaise" } },
        { "sesameBun", new Ingredient { IngredientName = "Sesame bun" } },
        { "blackBeanPatty", new Ingredient { IngredientName = "Black bean patty" } },
        { "avocado", new Ingredient { IngredientName = "Avocado" } },
        { "hummus", new Ingredient { IngredientName = "Hummus" } },
        { "wholeGrainBun", new Ingredient { IngredientName = "Whole grain bun" } },
        { "smokedApplewoodCheddar", new Ingredient { IngredientName = "Smoked applewood cheddar" } },
        { "crispyBacon", new Ingredient { IngredientName = "Crispy bacon" } },
        { "crispyChickenFillet", new Ingredient { IngredientName = "Crispy chicken fillet" } },
        { "ketchup", new Ingredient { IngredientName = "Ketchup" } },
        { "mustard", new Ingredient { IngredientName = "Mustard" } },
        { "jalapeno", new Ingredient { IngredientName = "Jalapeños" } },
        { "fishFillet", new Ingredient { IngredientName = "Fish fillet" } },
        { "cranberrySauce", new Ingredient { IngredientName = "Cranberry sauce" } },
        { "brieCheese", new Ingredient { IngredientName = "Brie cheese" } },
        { "grilledChicken", new Ingredient { IngredientName = "Grilled chicken" } },
        { "grilledLamb", new Ingredient { IngredientName = "Grilled lamb" } },
        { "donerWrap", new Ingredient { IngredientName = "Doner wrap" } },
        { "pitaBread", new Ingredient { IngredientName = "Pita bread" } },
        { "lavash", new Ingredient { IngredientName = "Lavash" } },
        { "garlicSauce", new Ingredient { IngredientName = "Garlic sauce" } },
        { "chiliSauce", new Ingredient { IngredientName = "Chili sauce" } },
        { "yogurtSauce", new Ingredient { IngredientName = "Yogurt sauce" } },
        { "redCabbage", new Ingredient { IngredientName = "Red cabbage" } },
        { "cucumber", new Ingredient { IngredientName = "Cucumber" } },
        { "rawOnion", new Ingredient { IngredientName = "Raw onion" } },
        { "parsley", new Ingredient { IngredientName = "Parsley" } },
        { "frenchFries", new Ingredient { IngredientName = "French fries" } },
        { "tomatoSauce", new Ingredient { IngredientName = "Tomato sauce" } },
        { "pickledPeppers", new Ingredient { IngredientName = "Pickled peppers" } },
        { "olives", new Ingredient { IngredientName = "Olives" } },
        { "rice", new Ingredient { IngredientName = "Rice" } },
        { "mozzarella", new Ingredient { IngredientName = "Mozzarella" } },
        { "tortillaChips", new Ingredient { IngredientName = "Tortilla chips" } },
        { "sourCream", new Ingredient { IngredientName = "Sour cream" } },
        { "salsa", new Ingredient { IngredientName = "Salsa" } },
        { "falafelMix", new Ingredient { IngredientName = "Falafel mix" } },
        { "breadcrumbs", new Ingredient { IngredientName = "Breadcrumbs" } },
        { "potatoes", new Ingredient { IngredientName = "Potatoes" } },
        { "batteringMix", new Ingredient { IngredientName = "Battering mix" } },
        { "cheddarCheeseSauce", new Ingredient { IngredientName = "Cheddar cheese sauce" } },
        { "eggs", new Ingredient { IngredientName = "Eggs" } },
        { "sunflowerOil", new Ingredient { IngredientName = "Sunflower oil" } },
        { "salt", new Ingredient { IngredientName = "Salt" } },
        { "sugar", new Ingredient { IngredientName = "Sugar" } },
        { "macaroni", new Ingredient { IngredientName = "Macaroni pasta" } },
        { "milk", new Ingredient { IngredientName = "Milk" } },
        { "flour", new Ingredient { IngredientName = "Flour" } },
        { "pepper", new Ingredient { IngredientName = "Black pepper" } },
        { "butter", new Ingredient { IngredientName = "Butter" } }
    };

    public static readonly Dictionary<string, Category> Categories = new()
    {
        { "burgers", new Category { CategoryName = "Burgers" } },
        { "doners", new Category { CategoryName = "Doners" } },
        { "snacks", new Category { CategoryName = "Snacks" } }
    };

    public static readonly List<Product> Products =
    [
        new()
        {
            ProductName = "Bacon Burger",
            InitialPrice = 8,
            DiscountPercentage = 25,
            ImageUrl = "/burgers/bacon_burger.png",
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
            ProductName = "Applewood Burger",
            InitialPrice = 10,
            ImageUrl = "/burgers/applewood_burger.png",
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
            ProductName = "Breakfast Burger",
            InitialPrice = 10,
            DiscountPercentage = 15,
            ImageUrl = "/burgers/breakfast_burger.png",
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
            ProductName = "Buffalo Burger",
            InitialPrice = 12,
            ImageUrl = "/burgers/buffalo_burger.png",
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
            ProductName = "Chicken Burger",
            InitialPrice = 8,
            DiscountPercentage = 20,
            ImageUrl = "/burgers/chicken_burger.png",
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
            ProductName = "Classic Burger",
            InitialPrice = 7,
            ImageUrl = "/burgers/classic_burger.png",
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
            ProductName = "Cranberry Burger",
            InitialPrice = 9,
            DiscountPercentage = 10,
            ImageUrl = "/burgers/cranberry_burger.png",
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
            ProductName = "Deluxe Burger",
            InitialPrice = 10,
            ImageUrl = "/burgers/deluxe_burger.png",
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
            ProductName = "Fish Burger",
            InitialPrice = 8,
            DiscountPercentage = 5,
            ImageUrl = "/burgers/fish_burger.png",
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
            ProductName = "Jalapeño Burger",
            InitialPrice = 10,
            ImageUrl = "/burgers/jalapeno_burger.png",
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
            ProductName = "Pulled Pork Burger",
            InitialPrice = 9,
            DiscountPercentage = 25,
            ImageUrl = "/burgers/pulled_pork_burger.png",
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
            ProductName = "Veggie Burger",
            InitialPrice = 8,
            ImageUrl = "/burgers/veggie_burger.png",
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
            ProductName = "Beef Döner",
            InitialPrice = 9,
            ImageUrl = "/doners/beef_doner.png",
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
            ProductName = "Chicken Döner",
            InitialPrice = 8,
            ImageUrl = "/doners/chicken_doner.png",
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
            ProductName = "Crispy Chicken Döner",
            InitialPrice = 9,
            ImageUrl = "/doners/crispy_chicken_doner.png",
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
            ProductName = "Lamb Döner",
            InitialPrice = 10,
            ImageUrl = "/doners/lamb_doner.png",
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
            ProductName = "Pork Döner",
            InitialPrice = 8,
            ImageUrl = "/doners/pork_doner.png",
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
            ProductName = "Spicy Pork Döner",
            InitialPrice = 9,
            ImageUrl = "/doners/spicy_pork_doner.png",
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
            ProductName = "Cheese Balls",
            InitialPrice = 4,
            ImageUrl = "/snacks/cheese_balls.png",
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
            ProductName = "Chicken Nuggets",
            InitialPrice = 5,
            ImageUrl = "/snacks/chicken_nuggets.png",
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
            ProductName = "Falafels",
            InitialPrice = 4,
            ImageUrl = "/snacks/falafels.png",
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
            ProductName = "French fries (Big)",
            InitialPrice = 3,
            ImageUrl = "/snacks/french_fries_big.png",
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
            ProductName = "French fries (Medium)",
            InitialPrice = 2.5,
            ImageUrl = "/snacks/french_fries_medium.png",
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
            ProductName = "French fries (Small)",
            InitialPrice = 2,
            ImageUrl = "/snacks/french_fries_small.png",
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
            ProductName = "Ketchup",
            InitialPrice = 0.5,
            ImageUrl = "/snacks/ketchup.png",
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
            ProductName = "Mayonnaise",
            InitialPrice = 0.5,
            ImageUrl = "/snacks/mayonnaise.png",
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
            ProductName = "Mozzarella Sticks",
            InitialPrice = 4.5,
            ImageUrl = "/snacks/mozzarella_sticks.png",
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
            ProductName = "Nachos",
            InitialPrice = 5,
            ImageUrl = "/snacks/nachos.png",
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
            ProductName = "Onion Rings",
            InitialPrice = 4,
            ImageUrl = "/snacks/onion_rings.png",
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
        },
        new()
        {
            ProductName = "Mac & Cheese",
            InitialPrice = 5.00,
            ImageUrl = "/snacks/mac_and_cheese.png",
            Description = "Creamy elbow macaroni baked in a rich cheddar cheese sauce, a classic comfort food favorite.",
            Calories = 450,
            Weight = 250,
            CategoryId = 3,
            Category = Categories["snacks"],
            DiscountPercentage = 0,
            Ingredients = new List<Ingredient>
            {
                Ingredients["macaroni"],
                Ingredients["cheddarCheese"],
                Ingredients["milk"],
                Ingredients["butter"],
                Ingredients["flour"],
                Ingredients["salt"],
                Ingredients["pepper"]
            }
        }
    ];
}