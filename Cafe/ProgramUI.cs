using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class ProgramUI
    {
        MenuRepo _menuRepo = new MenuRepo();
        IngredientRepo _ingredientRepo = new IngredientRepo();
        public void MainMenu()
        {
            SeedItems();
            Console.WindowWidth = 120;
            bool stillInLoop = true;
            while (stillInLoop)
            {
                Console.Clear();
                CompanyName();
                Console.WriteLine("   Please select an option below (1-4) \n" +
                    "\n");
                CoolColors("1. Add Menu Item");
                CoolColors("2. Delete Menu Item");
                CoolColors("3. View Menu Items");
                CoolColors("4. Exit");

                string entry = SetInputColor();
                int selection = TryParseInt(entry);
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        AddMenuItem();
                        break;
                    case 2:
                        Console.Clear();
                        DeleteMenuItem();
                        break;
                    case 3:
                        Console.Clear();
                        ViewMenuItems(2);
                        break;
                    case 4:
                        stillInLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection (1-4)");
                        AnyKey();
                        break;
                }
            }
        }





        private void AddMenuItem()
        {
            decimal price;
            bool isDecimal = false;
            string priceEntry;
            CompanyName();
            Console.WriteLine("To create a new menu item you need the items name, description, price, and a list of ingredients");
            Console.WriteLine("What is the name of the new Menu Item?");

            string mealName = SetInputColor();
            Console.WriteLine("What is a description of the new item?");

            string description = SetInputColor();
            do
            {
                Console.WriteLine("What is the cost of the item?");// This should be in a loop
                priceEntry = SetInputColor();
                isDecimal = decimal.TryParse(priceEntry, out price);
                if (isDecimal == false)
                {
                    Console.WriteLine("Please enter the cost of the item without a $ or , using only numbers and .");
                    AnyKey();
                }
            } while (isDecimal == false);
            Console.WriteLine("Enter a list of ingredients seperated by a comma. (Bun, Letuce, Mayo)");

            string ingredientEntry = SetInputColor();
            string[] items = ingredientEntry.Split(','); //Force Capitolization of first letter and removing white space and empty items #################################
            string cleanItem = "";
            string str;
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (string item in items)
            {
                str = item.TrimEnd(',', ' ');
                str = str.TrimStart(' ');
                if (str != "")
                {
                    cleanItem = char.ToUpper(str[0]) + str.Substring(1);
                    ingredients.Add(new Ingredient(cleanItem));
                }

            }
            _menuRepo.AddMeal(mealName, description, price, ingredients);
            Console.WriteLine("The menu item has been added.");
            AnyKey();
        }


        private void DeleteMenuItem()
        {
            int itemNumber;
            bool validEntry = false;
            do
            {
                ViewMenuItems(1);
                Console.WriteLine("Enter the number of the menu item you would like to delete.");
                string entry = SetInputColor();
                validEntry = int.TryParse(entry, out itemNumber);
                if (validEntry == false)
                {
                    Console.WriteLine("Please make a valid numeric entry.");
                    AnyKey();
                }
            } while (validEntry == false);
            bool success = _menuRepo.DeleteMenuItem(itemNumber);
            Console.WriteLine((success) ? $"The menu item {itemNumber} has been deleted" : $"The menu item {itemNumber} could not be deleted.");
            AnyKey();
        }
        private void ViewMenuItems(int x)
        {
            CompanyName();
            string ingredientList = "";
            switch (x)
            {
                case 1:
                    Console.WriteLine("{0, -8} {1,-15} {2, -10}", "Item #:", "Price", "Menu Item:");
                    foreach (Menu item in _menuRepo.GetAllMenuItems())
                    {

                        Console.WriteLine("\n{0, -8} {1,-15} {2, -10}", item.MealNumber, item.Price.ToString("C2"), item.MealName);
                    }
                    break;
                case 2:
                    int counter = 0;
                    foreach (Menu item in _menuRepo.GetAllMenuItems())
                    {
                        if (counter % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            counter++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            counter++;
                        }
                        //Console.WriteLine("\n{0, -8} {1,-8} {2, -10}", "Item #:", "Price", "Menu Item:");
                        Console.WriteLine("Item #: {0, -8} Price: {1,-8} Menu Item: {2, -10}", item.MealNumber, item.Price.ToString("C2"), item.MealName);
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine("Ingredients:");
                        foreach (Ingredient ingredient in item.MealIngredients)
                        {
                            if (ingredientList == "")
                            {
                                ingredientList = ingredient.IngredientName;
                            }
                            else
                            {
                                ingredientList = ingredientList + " - " + ingredient.IngredientName;
                            }
                        }
                        Console.WriteLine(ingredientList + "\n");
                        ingredientList = "";
                    }

                    AnyKey();
                    break;
                default:

                    foreach (Menu item in _menuRepo.GetAllMenuItems())
                    {
                        //Console.WriteLine("\n{0, -8} {1,-8} {2, -10}", "Item #:", "Price", "Menu Item:");
                        Console.WriteLine("Item #: {0, -8} Price: {1,-8} Menu Item: {2, -10}", item.MealNumber, item.Price.ToString("C2"), item.MealName);
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine("Ingredients:");
                        foreach (Ingredient ingredient in item.MealIngredients)
                        {

                            ingredientList = ingredientList + " - " + ingredient.IngredientName;
                        }
                        Console.WriteLine("\n" + ingredientList);
                        ingredientList = "";
                    }

                    AnyKey();
                    break;
            }


        }







        //Helper Methods
        private int TryParseInt(string entry)
        {
            int result = 0;
            try
            {
                result = int.Parse(entry);
                return result;
            }
            catch (Exception)
            {

                return 99;
            }
        }
        public void CompanyName()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\n	            	          	▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ \n" +
                            "		                      	▓                                    ▓ \n" +
                            "		          	        ▓  Komodo Cafe Point of Sale System  ▓ \n" +
                            "		                      	▓                                    ▓ \n" +
                            "		                      	▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ \n");
        }

        public void AnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        public void CoolColors(String text)
        {
            int count = 1;
            char[] letters = text.ToCharArray();
            foreach (char item in letters)
            {
                if (count <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(item);
                    count++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(item);
                    count++;
                }
            }
            Console.WriteLine("\n");
        }
        public string SetInputColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string input = Console.ReadLine();
            if (input.Length > 0)
            {
                string cleanItem = char.ToUpper(input[0]) + input.Substring(1);
                return cleanItem;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            return input;
        }




        public void SeedItems()
        {
            List<Ingredient> first = new List<Ingredient>();
            List<Ingredient> second = new List<Ingredient>();
            List<Ingredient> third = new List<Ingredient>();
            Ingredient bun = new Ingredient("Bun");
            Ingredient hamburgerPatty = new Ingredient("Hamburger Patty");
            Ingredient ketchup = new Ingredient("Ketchup");
            Ingredient mustard = new Ingredient("Mustard");
            Ingredient pickle = new Ingredient("Pickle");
            Ingredient cheese = new Ingredient("Cheese");
            Ingredient chickenPatty = new Ingredient("Chicken Patty");
            Ingredient mayo = new Ingredient("Mayo");


            first.Add(bun);
            first.Add(hamburgerPatty);
            first.Add(ketchup);
            first.Add(pickle);
            first.Add(mustard);

            second.Add(bun);
            second.Add(hamburgerPatty);
            second.Add(cheese);
            second.Add(ketchup);
            second.Add(pickle);
            second.Add(mustard);

            third.Add(bun);
            third.Add(chickenPatty);
            third.Add(pickle);
            third.Add(mustard);


            _menuRepo.AddMeal("Hamburger", "Juicy Burger fresh off the grill!", 6.99m, first);
            _menuRepo.AddMeal("Cheeseburger", "Juicy Burger fresh off the grill covered in cheese!", 7.49m, second);
            _menuRepo.AddMeal("Grilled Chicken Sandwich", "Juicy chicken breaks fresh off the grill with cheese", 8.99m, third);
        }


    }
}
