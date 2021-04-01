using ChallengeTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoSuite
{
    public class ProgramUI
    {
        ToolBox toolBox = new ToolBox();
        Badges.ProgramUI badges = new Badges.ProgramUI();
        Barbecue.ProgramUI barbecue = new Barbecue.ProgramUI();
        Cafe.ProgramUI cafe = new Cafe.ProgramUI();
        Claims.ProgramUI claims = new Claims.ProgramUI();
        Outings.ProgramUI companyOutings = new Outings.ProgramUI();
        public void MainMenu()
        {
            bool stayInLoop = true;
            string textEntry;
            while (stayInLoop)
            {
                Console.Clear();
                toolBox.CompanyName();
                Console.WriteLine("Select the application you would like to run.\n");
                toolBox.CoolColors("1. Badges");
                toolBox.CoolColors("2. Barbecue");
                toolBox.CoolColors("3. Cafe");
                toolBox.CoolColors("4. Claims");
                toolBox.CoolColors("5. Company Outings");
                toolBox.CoolColors("6. Exit");
                textEntry = toolBox.SetInputColor();
                switch (textEntry)
                {
                    case "1":
                        badges.MainMenu();
                        break;
                    case "2":
                        barbecue.MainMenu();
                        break;
                    case "3":
                        cafe.MainMenu();
                        break;
                    case "4":
                        claims.MainMenu();
                        break;
                    case "5":
                        companyOutings.MainMenu();
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
    }
}
