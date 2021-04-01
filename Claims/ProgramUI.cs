
using KomodoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ProgramUI
    {
        InsClaimRepo _insClaimRepo = new InsClaimRepo();
        KomodoTools kmTools = new KomodoTools();

        public void MainMenu()
        {
            SeedClaims();
            bool stillInLoop = true;
            int selection;
            bool validSelection = false;
            while (stillInLoop)
            {
                do
                {
                    Console.Clear();
                    kmTools.CompanyName();
                    Console.WriteLine("Enter Your Selection (1-5)\n");
                    kmTools.CoolColors("1. See All Claims:");
                    kmTools.CoolColors("2. See All Open Claims:");
                    kmTools.CoolColors("3. Work Next Open Claim:");
                    kmTools.CoolColors("4. Create New Claim:");
                    kmTools.CoolColors("5. Exit:");
                    string text = kmTools.SetInputColor();
                    validSelection = int.TryParse(text, out selection);
                    if (validSelection == false)
                    {
                        Console.WriteLine("Enter a numeric selction:");
                        kmTools.AnyKey();
                    }

                } while (validSelection == false);
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        kmTools.CompanyName();
                        SeeAllClaims();
                        break;
                    case 2:
                        Console.Clear();
                        kmTools.CompanyName();
                        SeeAllOpenClaims();
                        break;
                    case 3:
                        Console.Clear();
                        kmTools.CompanyName();
                        ProcessClaim();
                        break;
                    case 4:
                        Console.Clear();
                        kmTools.CompanyName();
                        InsClaim newClaim = CreateClaim();
                        string text;
                        do
                        {
                            kmTools.CompanyName();
                            DisplayClaim(newClaim);
                            Console.WriteLine("\n Add Claim To System (1-2)?");
                            kmTools.CoolColors("1. Yes (Add New Claim)");
                            kmTools.CoolColors("2. No (Abandon Claim)");
                            text = kmTools.SetInputColor();
                            validSelection = int.TryParse(text, out selection);
                            if (validSelection == false)
                            {
                                Console.WriteLine("Please enter 1 or 2.");
                            }

                        } while (validSelection == false);
                        if (selection == 1)
                        {
                            _insClaimRepo.AddClaim(newClaim);
                        }
                        else
                        {
                            Console.WriteLine("Claim discarded.");
                        }
                        kmTools.AnyKey();
                        break;
                    case 5:
                        stillInLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1-5");
                        kmTools.AnyKey();
                        break;
                }
            }
        }
        private void SeeAllClaims()
        {
            Console.WriteLine("{0,-10} {1,-7} {2,-50} {3,-12} {4, -17} {5,-22}",
                    "Claim ID", "Type", "Description", "Amount", "Date Of Incident", "Date Of Claim");
            foreach (InsClaim item in _insClaimRepo.GetAllClaims())
            {
                Console.WriteLine("{0,-10} {1,-7} {2,-50} {3,-12} {4, -17} {5,-22}"
                    , item.ID, item.Claim, item.Description, item.ClaimAmount.ToString("C2"), item.DateOfIncident.ToShortDateString(), item.DateOfClaim.ToShortDateString());
            }
            kmTools.AnyKey();
        }
        private void SeeAllOpenClaims()
        {
            Console.WriteLine("{0,-10} {1,-7} {2,-50} {3,-12} {4, -17} {5,-22}",
                    "Claim ID", "Type", "Description", "Amount", "Date Of Incident", "Date Of Claim");
            foreach (InsClaim item in _insClaimRepo.GetAllOpenClaims())
            {
                Console.WriteLine("{0,-10} {1,-7} {2,-50} {3,-12} {4, -17} {5,-22}"
                    , item.ID, item.Claim, item.Description, item.ClaimAmount.ToString("C2"), item.DateOfIncident.ToShortDateString(), item.DateOfClaim.ToShortDateString());
            }
            kmTools.AnyKey();
        }
        private void ProcessClaim()
        {

            InsClaim nextClaim = _insClaimRepo.GetNextClaim();
            DisplayClaim(nextClaim);
            Console.WriteLine("Is this the correct claim?");
            kmTools.CoolColors("1. Yes");
            kmTools.CoolColors("2. No");
            string text = kmTools.SetInputColor();
            int selection;
            bool validEntry = false;
            do
            {
                validEntry = int.TryParse(text, out selection);
                if (validEntry == false)
                {
                    Console.WriteLine("Please enter a 1 or 2");
                }
            } while (validEntry == false);
            if (selection == 2)
            {
                MainMenu();
            }
            text = "";
            selection = 0;

            Console.WriteLine("Would you like to Update or Close the claim?");
            kmTools.CoolColors("1. Update");
            kmTools.CoolColors("2. Close");
            text = kmTools.SetInputColor();
            do
            {
                validEntry = int.TryParse(text, out selection);
                if (validEntry == false)
                {
                    Console.WriteLine("Please enter a 1 or 2");
                }
            } while (validEntry == false);
            switch (selection)
            {
                case 1:
                    selection = 0;
                    validEntry = false;
                    InsClaim updateClaim = CreateClaim();
                    do
                    {
                        kmTools.CompanyName();
                        DisplayClaim(updateClaim);
                        Console.WriteLine("\n Update Claim?");
                        kmTools.CoolColors("1. Yes");
                        kmTools.CoolColors("2. No");
                        text = kmTools.SetInputColor();
                        validEntry = int.TryParse(text, out selection);
                        if (validEntry == false)
                        {
                            Console.WriteLine("Please enter 1 or 2.");
                        }

                    } while (validEntry == false);
                    if (selection == 1)
                    {
                        _insClaimRepo.UpdateClaim(updateClaim, nextClaim.ID);
                    }
                    else
                    {
                        Console.WriteLine("Claim discarded.");
                    }
                    kmTools.AnyKey();
                    break;
                case 2:
                    nextClaim.IsClaimOpen = false;
                    _insClaimRepo.UpdateClaim(nextClaim, nextClaim.ID);
                    break;
                default:
                    break;
            }
        }
        private InsClaim CreateClaim()
        {
            bool validSelection = false;
            int selection;
            string text = "";
            InsClaim newClaim = new InsClaim();
            Console.Clear();
            kmTools.CompanyName();
            Console.WriteLine("Please enter the following information to create a new claim:\n");
            do
            {
                Console.WriteLine("Select type of claim (1-3):");
                kmTools.CoolColors("1. Car");
                kmTools.CoolColors("2. Home");
                kmTools.CoolColors("3. Theft");
                text = kmTools.SetInputColor();
                validSelection = int.TryParse(text, out selection);
            } while (validSelection == false);
            switch (selection)
            {
                case 1:
                    newClaim.Claim = ClaimType.Car;
                    break;
                case 2:
                    newClaim.Claim = ClaimType.Home;
                    break;
                case 3:
                    newClaim.Claim = ClaimType.Theft;
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nDescribe the incident that led to the claim:");
            newClaim.Description = kmTools.SetInputColor();
            validSelection = false;
            decimal claimAmount = 0;
            do
            {
                Console.WriteLine("\nEnter the amount of the claim without '$' or ',':");
                text = kmTools.SetInputColor();
                validSelection = decimal.TryParse(text, out claimAmount);
                if (validSelection == false)
                {
                    Console.WriteLine("Please enter a decimal:");
                }
            } while (validSelection == false);
            newClaim.ClaimAmount = claimAmount;
            validSelection = false;
            DateTime incidentDate;
            do
            {
                Console.WriteLine("\nEnter the date of the incident in MM/DD/YYYY Format:");
                text = kmTools.SetInputColor();

                validSelection = DateTime.TryParse(text, out incidentDate);
                if (validSelection == false)
                {
                    Console.WriteLine("Please enter date in MM/DD/YYYY Format:");
                }
            } while (validSelection == false);
            newClaim.DateOfIncident = incidentDate;
            validSelection = false;
            DateTime claimDate;
            do
            {
                Console.WriteLine("\nEnter the date of the claim in MM/DD/YYYY Format:");
                text = kmTools.SetInputColor();

                validSelection = DateTime.TryParse(text, out claimDate);
                if (validSelection == false)
                {
                    Console.WriteLine("Please enter date in MM/DD/YYYY Format:");
                }
            } while (validSelection == false);
            newClaim.DateOfClaim = claimDate;
            Console.Clear();
            text = "";
            selection = 0;
            return newClaim;
        }
        private void DisplayClaim(InsClaim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ID}\n" +
                $"Claim Type: {claim.Claim}\n" +
                $"Description: {claim.Description}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date Of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                $"Date Of Claim {claim.DateOfClaim.ToShortDateString()}\n" +
                $"Is Claim Valid {claim.IsValid}\n" +
                $"Claim Creation Date {claim.ClaimCreationDate.ToShortDateString()}");
        }
        private void SeedClaims()
        {
            DateTime dateOfIncident1 = new DateTime(2021, 03, 07);
            DateTime dateOfClaim1 = new DateTime(2021, 03, 17);
            InsClaim claim1 = new InsClaim(1, ClaimType.Car, "Tree jumped in front of me", 12232.43m, dateOfIncident1, dateOfClaim1, true);

            DateTime dateOfIncident2 = new DateTime(2021, 01, 07);
            DateTime dateOfClaim2 = new DateTime(2021, 03, 07);
            InsClaim claim2 = new InsClaim(2, ClaimType.Home, "Tree chased me home and jumped on my roof", 31132.73m, dateOfIncident2, dateOfClaim2, true);

            DateTime dateOfIncident3 = new DateTime(2020, 12, 07);
            DateTime dateOfClaim3 = new DateTime(2020, 12, 17);
            InsClaim claim3 = new InsClaim(3, ClaimType.Theft, "Tree stole my wallet", 292.63m, dateOfIncident3, dateOfClaim3, true);

            _insClaimRepo.AddClaim(claim1);
            _insClaimRepo.AddClaim(claim2);
            _insClaimRepo.AddClaim(claim3);
        }
    }
}
