using Cafe;
using ChallengeTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbecue
{
    public class ProgramUI
    {
        ToolBox toolBox = new ToolBox();
        PartyRepo _partyRepo = new PartyRepo();
        decimal hamburgerCost = 6.99m;
        decimal veggieburgerCost = 7.99m;
        decimal hotdogCost = 3.99m;
        decimal icecreamCost = 2.99m;
        decimal popcornCost = .99m;
        public void MainMenu()
        {
            SeedParties();
            bool stayInLoop = true;
            string textEntry;
            while (stayInLoop)
            {
                Console.Clear();
                toolBox.CompanyName();

                Console.WriteLine("Please select one of the options below\n");
                toolBox.CoolColors("1. Add Party");
                toolBox.CoolColors("2. View Parties");
                toolBox.CoolColors("3. Set Prices");
                toolBox.CoolColors("4. Exit");
                textEntry = toolBox.SetInputColor();

                switch (textEntry)
                {
                    case "1":
                        AddParty();
                        break;
                    case "2":
                        ListParties();
                        break;
                    case "3":
                        SetPrices();
                        break;
                    case "4":
                        stayInLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a vaild selection (1-3)");
                        break;
                }
            }
        }
        private void AddParty()
        {
            List<Menu> menuItems = new List<Menu>();
            string inputText;
            bool validEntry = false;
            int hamburgers = 0;
            int veggieburgers = 0;
            int hotdogs = 0;
            int icecreams = 0;
            int popcorn = 0;
            Console.Clear();
            toolBox.CompanyName();
            Console.WriteLine("I think it was P!nk who said lets get this party started!\n");
            string partyName = toolBox.SameLineInput("What should we call this party?: ");
            do
            {
                inputText = toolBox.SameLineInput("How many tickets were used for Hamburgers? (Please enter a number): ");
                validEntry = int.TryParse(inputText, out hamburgers);
                if (validEntry == false)
                {
                    Console.WriteLine("Please Enter a number");
                    toolBox.AnyKey();
                    RebuildParty(partyName, 0, hamburgers, veggieburgers, hotdogs, icecreams, popcorn);
                }
            } while (validEntry == false);
            validEntry = false;

            do
            {
                inputText = toolBox.SameLineInput("How many tickets were used for Veggie Burgers? (Please enter a number): ");
                validEntry = int.TryParse(inputText, out veggieburgers);
                if (validEntry == false)
                {
                    Console.WriteLine("Please Enter a number");
                    toolBox.AnyKey();
                    RebuildParty(partyName, 1, hamburgers, veggieburgers, hotdogs, icecreams, popcorn);
                }
            } while (validEntry == false);
            validEntry = false;

            do
            {
                inputText = toolBox.SameLineInput("How many tickets were used for Hotdogs? (Please enter a number): ");
                validEntry = int.TryParse(inputText, out hotdogs);
                if (validEntry == false)
                {
                    Console.WriteLine("Please Enter a number");
                    toolBox.AnyKey();
                    RebuildParty(partyName, 2, hamburgers, veggieburgers, hotdogs, icecreams, popcorn);
                }
            } while (validEntry == false);
            validEntry = false;

            do
            {
                inputText = toolBox.SameLineInput("How many tickets were used for Ice Cream? (Please enter a number): ");
                validEntry = int.TryParse(inputText, out icecreams);
                if (validEntry == false)
                {
                    Console.WriteLine("Please Enter a number");
                    toolBox.AnyKey();
                    RebuildParty(partyName, 3, hamburgers, veggieburgers, hotdogs, icecreams, popcorn);
                }
            } while (validEntry == false);
            validEntry = false;

            do
            {
                inputText = toolBox.SameLineInput("How many tickets were used for Popcorn? (Please enter a number): ");
                validEntry = int.TryParse(inputText, out popcorn);
                if (validEntry == false)
                {
                    Console.WriteLine("Please Enter a number");
                    toolBox.AnyKey();
                    RebuildParty(partyName, 4, hamburgers, veggieburgers, hotdogs, icecreams, popcorn);
                }
            } while (validEntry == false);

            menuItems = CreateMenu(hamburgers, veggieburgers, hotdogs, icecreams, popcorn);
            _partyRepo.AddParty(partyName, menuItems);

            toolBox.AnyKey();
        }

        private List<Menu> CreateMenu(int hamburgers, int veggieburgers, int hotdogs, int icecreams, int popcorn)
        {
            List<Menu> returnMenu = new List<Menu>();
            for (int i = 0; i < hamburgers; i++)
            {
                Menu item = new Menu();
                item.MealNumber = 1;
                item.MealName = "Hamburger";
                item.Price = hamburgerCost;
                returnMenu.Add(item);
            }
            for (int i = 0; i < veggieburgers; i++)
            {
                Menu item = new Menu();
                item.MealNumber = 2;
                item.MealName = "Veggie Burger";
                item.Price = veggieburgerCost;
                returnMenu.Add(item);
            }
            for (int i = 0; i < hotdogs; i++)
            {
                Menu item = new Menu();
                item.MealNumber = 3;
                item.MealName = "Hot Dog";
                item.Price = hotdogCost;
                returnMenu.Add(item);
            }
            for (int i = 0; i < icecreams; i++)
            {
                Menu item = new Menu();
                item.MealNumber = 4;
                item.MealName = "Ice Cream";
                item.Price = icecreamCost;
                returnMenu.Add(item);
            }
            for (int i = 0; i < popcorn; i++)
            {
                Menu item = new Menu();
                item.MealNumber = 5;
                item.MealName = "Popcorn";
                item.Price = popcornCost;
                returnMenu.Add(item);
            }
            return returnMenu;
        }

        private void SetPrices()
        {
            bool stayInLoop = true;
            string textEntry;
            string newPrice;
            decimal itemPrice;
            while (stayInLoop)
            {
                Console.Clear();
                toolBox.CompanyName();
                Console.WriteLine("Current Product Prices:");
                toolBox.CoolColors("1. Hamburger: " + hamburgerCost.ToString("C2"));
                toolBox.CoolColors("2. Veggie Burger: " + veggieburgerCost.ToString("C2"));
                toolBox.CoolColors("3. Hotdog: " + hotdogCost.ToString("C2"));
                toolBox.CoolColors("4. Ice Cream: " + icecreamCost.ToString("C2"));
                toolBox.CoolColors("5. Popcorn: " + popcornCost.ToString("C2"));
                toolBox.CoolColors("6. Exit");
                Console.WriteLine("Enter the item number to update its price.");
                textEntry = toolBox.SetInputColor();
                switch (textEntry)
                {
                    case "1":
                        Console.Write("New Hamburger Price: ");
                        newPrice = toolBox.SetInputColor();
                        if (decimal.TryParse(newPrice, out itemPrice))
                        {
                            hamburgerCost = itemPrice;
                        }
                        else
                        {
                            Console.WriteLine("Couldn't Update Hamburger Price");
                            toolBox.AnyKey();
                        }
                        itemPrice = 0;
                        newPrice = "";
                        break;
                    case "2":
                        Console.Write("New Veggie Burger Price: ");
                        newPrice = toolBox.SetInputColor();
                        if (decimal.TryParse(newPrice, out itemPrice))
                        {
                            veggieburgerCost = itemPrice;
                        }
                        else
                        {
                            Console.WriteLine("Couldn't Update Veggie Burger Price");
                            toolBox.AnyKey();
                        }
                        itemPrice = 0;
                        newPrice = "";
                        break;
                    case "3":
                        Console.Write("New Hotdog Price: ");
                        newPrice = toolBox.SetInputColor();
                        if (decimal.TryParse(newPrice, out itemPrice))
                        {
                            hotdogCost = itemPrice;
                        }
                        else
                        {
                            Console.WriteLine("Couldn't Update Hotdog Price");
                            toolBox.AnyKey();
                        }
                        itemPrice = 0;
                        newPrice = "";
                        break;
                    case "4":
                        Console.Write("New Ice Cream Price: ");
                        newPrice = toolBox.SetInputColor();
                        if (decimal.TryParse(newPrice, out itemPrice))
                        {
                            icecreamCost = itemPrice;
                        }
                        else
                        {
                            Console.WriteLine("Couldn't Update Ice Cream Price");
                            toolBox.AnyKey();
                        }
                        itemPrice = 0;
                        newPrice = "";
                        break;
                    case "5":
                        Console.Write("New Popcorn Price: ");
                        newPrice = toolBox.SetInputColor();
                        if (decimal.TryParse(newPrice, out itemPrice))
                        {
                            popcornCost = itemPrice;
                        }
                        else
                        {
                            Console.WriteLine("Couldn't Update Popcorn Price");
                            toolBox.AnyKey();
                        }
                        itemPrice = 0;
                        newPrice = "";
                        break;
                    case "6":
                        stayInLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection (1-6)");
                        toolBox.AnyKey();
                        break;
                }
            }
        }
        private void ListParties()
        {
            int colorCount = 0;
            int hamburgers = 0;
            int veggieburgers = 0;
            int hotdogs = 0;
            int icecreams = 0;
            int popcorn = 0;
            int burgerBooth = 0;
            int treatBooth = 0;

            foreach (Party item in _partyRepo.GetParties())
            {
                hamburgers = 0;
                veggieburgers = 0;
                hotdogs = 0;
                icecreams = 0;
                popcorn = 0;
                burgerBooth = 0;
                treatBooth = 0;
                if (colorCount % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine($"\nParty Name: {item.Name} Total Cost: {item.Cost.ToString("C2")} Total Tickets: {item.MenuID.Count}\n");
                foreach (Menu menuitem in item.MenuID)
                {
                    switch (menuitem.MealNumber)
                    {
                        case 1:
                            hamburgers++;
                            burgerBooth++;
                            break;
                        case 2:
                            veggieburgers++;
                            burgerBooth++;
                            break;
                        case 3:
                            hotdogs++;
                            burgerBooth++;
                            break;
                        case 4:
                            icecreams++;
                            treatBooth++;
                            break;
                        case 5:
                            popcorn++;
                            treatBooth++;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("{0,-45}{1,-45}", "Burger Booth Tickets: " + burgerBooth.ToString(), "Treat Booth Tickets: " + treatBooth.ToString());
                Console.WriteLine("{0,-45}{1,-45}", "Hamburger Tickets: " + hamburgers, "Icecream Tickets: " + icecreams);
                Console.WriteLine("{0,-45}{1,-45}", "Veggie Burger Tickets: " + veggieburgers, "Popcorn Tickets: " + popcorn);
                Console.WriteLine("{0,-45}", "Hotdog Tickets: " + hotdogs.ToString());
                colorCount++;
            }
            toolBox.AnyKey();
        }
        private void RebuildParty(string name, int step, int hamburgers, int veggieburgers, int hotdogs, int icecreams, int popcorn)
        {
            Console.Clear();
            toolBox.CompanyName();
            Console.Write("Party: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.Blue;
            switch (step)
            {
                case 0:
                    break;
                case 1:
                    Console.Write("Number of Hamburgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hamburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.Write("Number of Hamburgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hamburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Veggie Burgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(veggieburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 3:
                    Console.Write("Number of Hamburgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hamburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Veggie Burgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(veggieburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of HotDogs: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hotdogs);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.Write("Number of Hamburgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hamburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Veggie Burgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(veggieburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Hotdogs: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hotdogs);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Ice Creams: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(icecreams);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 5:
                    Console.Write("Number of Hamburgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hamburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Veggie Burgers: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(veggieburgers);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Hotdogs: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(hotdogs);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Ice Creams: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(icecreams);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Number of Popcorn: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(popcorn);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }
        }
        private void SeedParties()
        {
            List<Menu> menu1 = new List<Menu>();
            menu1 = CreateMenu(15, 10, 23, 10, 32);
            _partyRepo.AddParty("Summer Party", menu1);
            List<Menu> menu2 = new List<Menu>();
            menu2 = CreateMenu(1, 1, 1, 1, 1);
            _partyRepo.AddParty("Easy Math - Total should be 22.95", menu2);
            List<Menu> menu3 = new List<Menu>();
            menu3 = CreateMenu(115, 101, 23, 1, 32);
            _partyRepo.AddParty("Ballers Ball", menu3);
            List<Menu> menu4 = new List<Menu>();
            menu4 = CreateMenu(1, 0, 0, 1, 1);
            _partyRepo.AddParty("Some 0s", menu4);
        }
    }
}
