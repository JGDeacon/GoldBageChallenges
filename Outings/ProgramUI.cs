
using ChallengeTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public class ProgramUI
    {
        ToolBox toolBox = new ToolBox();
        EventRepo _eventRepo = new EventRepo();
        Reports reports = new Reports();
        decimal totalEventCost = 0m;
        public void MainMenu()
        {
            SeedData();
            bool stillInLoop = true;
            while (stillInLoop)
            {
                toolBox.CompanyName();
                Console.WriteLine("Pick from the following options");
                Console.WriteLine("(A)dd an Outing");
                Console.WriteLine("(L)ist all Outings");
                Console.WriteLine("(V)iew Reports");
                Console.WriteLine("e(X)it");
                string selection = Console.ReadLine().ToUpper();
                switch (selection)
                {
                    case "A":
                        AddOuting();
                        break;
                    case "L":
                        ListOutings(_eventRepo.GetEvents(), false);
                        break;
                    case "V":
                        ReportMenu();
                        break;
                    case "X":
                        stillInLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please pick from A, L, V, or X");
                        break;
                }
            }
        }
        private void AddOuting()
        {
            toolBox.CompanyName();
            bool questionLoop = true;
            string response;
            Events eventType = new Events();
            int attendance;
            DateTime eventDate;
            decimal eventCost;
            do
            {
                Console.WriteLine("What type outing was held? (G)olf, (B)owling, (A)musement Park, or (C)oncert");
                response = Console.ReadLine().ToUpper();
                switch (response)
                {
                    case "G":
                        eventType = Events.Golf;
                        questionLoop = true;
                        break;
                    case "A":
                        eventType = Events.AmusementPark;
                        questionLoop = true;
                        break;
                    case "B":
                        eventType = Events.Bowling;
                        questionLoop = true;
                        break;
                    case "C":
                        eventType = Events.Concert;
                        questionLoop = true;
                        break;
                    default:
                        Console.WriteLine("Please enter G, B, A, or C.");
                        questionLoop = false;
                        break;
                }
            } while (questionLoop == false);
            toolBox.CompanyName();
            questionLoop = false;
            do
            {
                Console.WriteLine("How many people attended the outing?");
                questionLoop = int.TryParse(Console.ReadLine(), out attendance);
                if (questionLoop == false)
                {
                    Console.WriteLine("Please enter a number.\n Press any key to continue.");
                    Console.ReadKey();
                }
            } while (questionLoop == false);
            toolBox.CompanyName();
            questionLoop = false;
            do
            {
                Console.WriteLine("What was the date of the outing? (MM/DD/YYYY Format)");
                questionLoop = DateTime.TryParse(Console.ReadLine(), out eventDate);
                if (questionLoop == false)
                {
                    Console.WriteLine("Please enter a date in MM/DD/YYYY format.\n Press any key to continue.");
                    Console.ReadKey();
                }
            } while (questionLoop == false);
            toolBox.CompanyName();
            questionLoop = false;
            do
            {
                Console.WriteLine("What was the cost of the outing? (Please exclude $ and , from the number)");
                questionLoop = decimal.TryParse(Console.ReadLine(), out eventCost);
                if (questionLoop == false)
                {
                    Console.WriteLine("Please enter an amount without formatting (ie: 21332.55). \nPress any key to continue.");
                    Console.ReadKey();
                }
            } while (questionLoop == false);
            _eventRepo.AddEvent(eventType, attendance, eventDate, eventCost);
            toolBox.CompanyName();
        }
        private void ListOutings(List<Event> events, bool showTotals)
        {
            string eventType;
            toolBox.CompanyName();
            Console.WriteLine("{0,-20} {1, -12} {2, -15} {3, -15} {4, -9}", "Outing:", "Attendees:", "Event Date:", "Event Cost", "Cost Per Person");
            foreach (Event item in events)
            {
                //eventType = (item.EventType == Events.AmusementPark) ? "Amusement Park" : item.EventType.ToString();
                Console.WriteLine("{0,-20} {1, -12} {2, -15} {3, -15} {4, -9}",
                    (item.EventType == Events.AmusementPark) ? "Amusement Park" : item.EventType.ToString(), 
                    item.Attendance, item.EventDate.ToShortDateString(), item.EventCost.ToString("C2"), item.CostPP.ToString("C2"));
                totalEventCost = totalEventCost + item.EventCost;
            }
            if (showTotals)
            {
                Console.WriteLine($"\n{events.Count} Outings with a total cost of {totalEventCost.ToString("C2")}");
            }
            toolBox.AnyKey();
        }
        private void ReportMenu()
        {
            List<Event> workingEventList = new List<Event>();
            List<Event> sortedEventList = new List<Event>();
            int sortType = 0;
            bool ascending = true;
            string selectionText;
            bool validInput = false;
            bool stillInLoop = false;
            toolBox.CompanyName();
            Console.WriteLine("Reports offers you a number of ways to present data on outings. \n" +
                "You can limit and filter the results by certian data points\n");
            do
            {
                stillInLoop = false;
                validInput = false;
                Console.WriteLine("Please select your data set for the report\n" +
                    "(A)ttendance (Range)\n" +
                    "(E)vent Date (Range)\n" +
                    "(O)uting Type\n" +
                    "(T)otal Cost (Range)\n" +
                    "(P)er Person Cost (Range)\n" +
                    "(D)efault Show All Data\n" +
                    "e(X)it");
                selectionText = Console.ReadLine().ToUpper();
                toolBox.CompanyName();
                Console.WriteLine("Reports offers you a number of ways to present data on outings. \n" +
                    "You can limit and filter the results by certian data points\n");
                switch (selectionText)
                {
                    case "A":
                        int startAttendance;
                        int endAttendance;
                        do
                        {
                            Console.WriteLine("What is the minimum attendees?");
                            validInput = int.TryParse(Console.ReadLine(), out startAttendance);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter a number. \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        validInput = false;
                        do
                        {
                            Console.WriteLine("What is the maximum attendees?");
                            validInput = int.TryParse(Console.ReadLine(), out endAttendance);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter a number. \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        workingEventList = reports.GetMatchingEvents(_eventRepo.GetEvents(), startAttendance, endAttendance);
                        break;
                    case "E":
                        DateTime startRange;
                        DateTime endRange;
                        do
                        {
                            Console.WriteLine("What was the date of the outing? (MM/DD/YYYY Format)");
                            validInput = DateTime.TryParse(Console.ReadLine(), out startRange);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter a date in MM/DD/YYYY format. \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        validInput = false;
                        do
                        {
                            Console.WriteLine("What was the date of the outing? (MM/DD/YYYY Format)");
                            validInput = DateTime.TryParse(Console.ReadLine(), out endRange);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter a date in MM/DD/YYYY format. \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        workingEventList = reports.GetMatchingEvents(_eventRepo.GetEvents(), startRange, endRange);
                        break;
                    case "O":
                        validInput = false;
                        selectionText = "";
                        Events eventType = new Events();
                        do
                        {
                            Console.WriteLine("What type outing was held? (G)olf, (B)owling, (A)musement Park, or (C)oncert");
                            selectionText = Console.ReadLine().ToUpper();


                            switch (selectionText)
                            {
                                case "G":
                                    eventType = Events.Golf;
                                    validInput = true;
                                    break;
                                case "A":
                                    eventType = Events.AmusementPark;
                                    validInput = true;
                                    break;
                                case "B":
                                    eventType = Events.Bowling;
                                    validInput = true;
                                    break;
                                case "C":
                                    eventType = Events.Concert;
                                    validInput = true;
                                    break;
                                default:
                                    Console.WriteLine("Please enter G, B, A, or C.");
                                    validInput = false;
                                    break;
                            }

                        } while (validInput == false);
                        workingEventList = reports.GetMatchingEvents(_eventRepo.GetEvents(), eventType);
                        break;
                    case "T":
                        decimal startTotalCost;
                        decimal endTotalCost;

                        validInput = false;
                        do
                        {
                            Console.WriteLine("What is the minimum outing cost? (Please exclude $ and , from the number)");
                            validInput = decimal.TryParse(Console.ReadLine(), out startTotalCost);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter an amount without formatting (ie: 21332.55). \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        validInput = false;
                        do
                        {
                            Console.WriteLine("What is the maximum outing cost? (Please exclude $ and , from the number)");
                            validInput = decimal.TryParse(Console.ReadLine(), out endTotalCost);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter an amount without formatting (ie: 21332.55). \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        workingEventList = reports.GetMatchingEvents(_eventRepo.GetEvents(), startTotalCost, endTotalCost, "Total Cost");
                        break;
                    case "P":
                        decimal startPP;
                        decimal endPP;
                        validInput = false;
                        do
                        {
                            Console.WriteLine("What is the minimum outing cost per person? (Please exclude $ and , from the number)");
                            validInput = decimal.TryParse(Console.ReadLine(), out startPP);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter an amount without formatting (ie: 21332.55). \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        validInput = false;
                        do
                        {
                            Console.WriteLine("What is the maximum outing cost per person? (Please exclude $ and , from the number)");
                            validInput = decimal.TryParse(Console.ReadLine(), out endPP);
                            if (validInput == false)
                            {
                                Console.WriteLine("Please enter an amount without formatting (ie: 21332.55). \n Press any key to continue.");
                                Console.ReadKey();
                            }
                        } while (validInput == false);
                        workingEventList = reports.GetMatchingEvents(_eventRepo.GetEvents(), startPP, endPP, "Per Person Cost");
                        //DoSometing
                        break;
                    case "D":
                        workingEventList = _eventRepo.GetEvents();
                        break;
                    case "X":
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter A, E, O, T, P, or D");
                        stillInLoop = true;
                        break;
                }
            } while (stillInLoop);

            toolBox.CompanyName();
            Console.WriteLine("Reports offers you a number of ways to present data on outings. \n" +
                "You can limit and filter the results by certian data points\n");
            do
            {
                selectionText = "";
                stillInLoop = false;
                Console.WriteLine("How would you like to sort your data set?\n" +
                    "(A)ttendance\n" +
                    "(E)vent Date\n" +
                    "(O)uting Type\n" +
                    "(T)otal Cost\n" +
                    "(P)er Person Cost\n");
                selectionText = Console.ReadLine().ToUpper();
                switch (selectionText)
                {
                    case "A":
                        sortType = 2;
                        break;
                    case "E":
                        sortType = 5;
                        break;
                    case "O":
                        sortType = 1;
                        break;
                    case "T":
                        sortType = 3;
                        break;
                    case "P":
                        sortType = 4;
                        break;
                    default:
                        Console.WriteLine("Please enter A, E, O, T, or P");
                        stillInLoop = true;
                        break;
                }
            } while (stillInLoop);
            toolBox.CompanyName();
            Console.WriteLine("Reports offers you a number of ways to present data on outings. \n" +
                "You can limit and filter the results by certian data points\n");

            do
            {
                stillInLoop = false;
                selectionText = "";
                Console.WriteLine("Would you like to sort\n" +
                    "(A)scending\n" +
                    "(D)escending");
                selectionText = Console.ReadLine().ToUpper();
                if (selectionText == "A")
                {
                    ascending = true;
                }
                else if (selectionText == "D")
                {
                    ascending = false;
                }
                else
                {
                    Console.WriteLine("Please enter A or D");
                    stillInLoop = true;
                }
            } while (stillInLoop);
            sortedEventList = reports.OrderEvents(workingEventList, sortType, ascending);

            ListOutings(sortedEventList, true);           
        }
        private void SeedData()
        {
            DateTime dateTime = DateTime.Parse("03/12/2021");
            DateTime dateTime2 = DateTime.Parse("02/12/2021");
            DateTime dateTime3 = DateTime.Parse("03/02/2021");
            DateTime dateTime4 = DateTime.Parse("01/31/2021");
            DateTime dateTime5 = DateTime.Parse("06/8/2020");
            DateTime dateTime6 = DateTime.Parse("10/31/2020");
            _eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 12250.50m);
            _eventRepo.AddEvent(Events.Golf, 30, dateTime2, 6250.50m);
            _eventRepo.AddEvent(Events.Concert, 56, dateTime3, 22250.50m);
            _eventRepo.AddEvent(Events.Bowling, 12, dateTime4, 1250.50m);
            _eventRepo.AddEvent(Events.AmusementPark, 500, dateTime5, 250.50m);
            _eventRepo.AddEvent(Events.Concert, 233, dateTime6, 2250.50m);
        }
    }
}
