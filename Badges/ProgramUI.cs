using KomodoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class ProgramUI
    {
        BadgeRepo _badgeRepo = new BadgeRepo();
        KomodoTools kmTools = new KomodoTools();
        public void MainMenu()
        {
            SeedBadges();
            string text;            
            int selection;

            bool stillInLoop = true;
            while (stillInLoop)
            {
                Console.Clear();
                kmTools.CompanyName();
                Console.WriteLine("Please enter a selection (1-6)\n");
                kmTools.CoolColors("1. Add Badge");
                kmTools.CoolColors("2. Update Badge");
                kmTools.CoolColors("3. Clear Badge Access");
                kmTools.CoolColors("4. List All Badges");
                kmTools.CoolColors("5. Search Badges By Door");
                kmTools.CoolColors("6. Exit");
                text = kmTools.SetInputColor();
                int.TryParse(text, out selection);
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        kmTools.CompanyName();
                        AddBadge();
                        break;
                    case 2:
                        Console.Clear();
                        kmTools.CompanyName();
                        UpdateBadge();
                        break;
                    case 3:
                        Console.Clear();
                        kmTools.CompanyName();
                        ClearBadge();
                        break;
                    case 4:
                        Console.Clear();
                        kmTools.CompanyName();
                        ListAllBadges();
                        break;
                    case 5:
                        Console.Clear();
                        kmTools.CompanyName();
                        Console.WriteLine("What door would you like to search for?");
                        string door = kmTools.SetInputColor();
                        SearchBadgesBadge(door);
                        break;
                    case 6:
                        stillInLoop = false;
                        break;
                    default:
                        break;
                }
            }

        }
        private void AddBadge()
        {
            string text = "";
            string doors = "";
            int doorCheck;
            do
            {
                doorCheck = 0;
                Console.WriteLine("Please enter the door this badge has access to:");
                doors = doors + kmTools.SetInputColor() + ", ";

                Console.WriteLine("Would you like to add an additional door to the badge?");
                kmTools.CoolColors("1. Yes");
                Console.WriteLine("Any key for No");
                text = kmTools.SetInputColor();
                int.TryParse(text, out doorCheck);


            } while (doorCheck == 1);

            string[] items = doors.Split(','); //string cleanup
            string cleanItem = "";
            string str;
            string doorList = "";
            foreach (string item in items)

            {
                str = item.TrimEnd(',', ' ');
                str = str.TrimStart(' ');
                if (str != "")
                {
                    cleanItem = char.ToUpper(str[0]) + str.Substring(1);
                    doorList = doorList + ", " + cleanItem;
                }
            }
            doorList = doorList.TrimStart(',');
            doorList = doorList.TrimStart(' ');
            _badgeRepo.AddBadge(doorList);
        }
        private void UpdateBadge()
        {
            bool validEntry = false;
            string text;
            int selection;
            do
            {
                Console.Clear();
                kmTools.CompanyName();
                Dictionary<int, string> badgeValuePairs = _badgeRepo.ListAllBadges();
                badgeValuePairs = _badgeRepo.ListAllBadges();
                Console.WriteLine("Current Badges \n");
                foreach (int item in badgeValuePairs.Keys)
                {
                    Console.WriteLine($"ID: {item.ToString()} Doors: {badgeValuePairs[item].ToString()}");
                }
                Console.WriteLine("\nPlease enter a numeric Badge ID you would like to update");
                text = kmTools.SetInputColor();
                validEntry = int.TryParse(text, out selection);
                if (validEntry == false)
                {
                    Console.WriteLine("Badge ID's can only contain numbers. Please try again.");
                    kmTools.AnyKey();
                }
                if (selection > _badgeRepo.ListAllBadges().Count)
                {
                    Console.WriteLine("That Badge number doesn't exist. Please try again.");
                    validEntry = false;
                    kmTools.AnyKey();
                }
            } while (validEntry == false);
            text = "";
            string doors = "";
            int doorCheck;
            do
            {
                doorCheck = 0;
                Console.WriteLine("Please enter the door this badge has access to:");
                doors = doors + kmTools.SetInputColor() + ", ";

                Console.WriteLine("Would you like to add an additional door to the badge?");
                kmTools.CoolColors("1. Yes");
                kmTools.CoolColors("2. No");
                text = kmTools.SetInputColor();
                int.TryParse(text, out doorCheck);


            } while (doorCheck == 1);
            string[] items = doors.Split(','); //string cleanup
            string cleanItem = "";
            string str;
            string doorList = "";
            foreach (string item in items)
            {
                str = item.TrimEnd(',', ' ');
                str = str.TrimStart(' ');
                if (str != "")
                {
                    cleanItem = char.ToUpper(str[0]) + str.Substring(1);
                    doorList = doorList + ", " + cleanItem;
                }
            }
            doorList = doorList.TrimStart(',');
            doorList = doorList.TrimStart(' ');            
            _badgeRepo.EditBadge(selection, doorList);
            kmTools.AnyKey();
        }
        private void ClearBadge()
        {
            bool validEntry = false;
            string text;
            int selection;
            do
            {
                Console.Clear();
                kmTools.CompanyName();
                Console.WriteLine("Please enter a numeric Badge ID you would like to clear door access");
                text = kmTools.SetInputColor();
                validEntry = int.TryParse(text, out selection);
                if (validEntry == false)
                {
                    Console.WriteLine("Badge ID's can only contain numbers. Please try again.");
                    kmTools.AnyKey();
                }
            } while (validEntry == false);
            _badgeRepo.ClearBadge(selection);
            kmTools.AnyKey();
        }
        private void ListAllBadges()
        {
            Dictionary<int, string> badgeValuePairs = _badgeRepo.ListAllBadges();
            badgeValuePairs = _badgeRepo.ListAllBadges();

            foreach (int item in badgeValuePairs.Keys)
            {
                Console.WriteLine($"ID: {item.ToString()} Doors: {badgeValuePairs[item].ToString()}");
            }
            kmTools.AnyKey();
        }
        private void SearchBadgesBadge(string door)
        {
            List<int> badgeValuePairs = _badgeRepo.ListMatchingDoor(door);

            Console.WriteLine("These ID's have access to the door.");
            foreach (int item in badgeValuePairs)
            {
                Console.WriteLine($"ID: {item}");
            }
            kmTools.AnyKey();
        }

        private void SeedBadges()
        {
            _badgeRepo.AddBadge("Hallway, Bathroom, Outside, Main");
            _badgeRepo.AddBadge("Main, Bathroom, Outside, Main");
            _badgeRepo.AddBadge("Main, Bed, Outside, Main");
            _badgeRepo.AddBadge("Playground, Bathroom, Outside, Main");
            _badgeRepo.AddBadge("Hallway, Garage, Outside, Windows");
            _badgeRepo.AddBadge("Hallway, Kitchen, Outside, Main");
        }

    }
}
