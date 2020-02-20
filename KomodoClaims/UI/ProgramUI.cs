using _01_KomodoClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.UI
{
    class ProgramUI
    {
        private readonly KomodoClaimsRepo _claimRepo = new KomodoClaimsRepo();
        public void Run()
        {
            // SeedContent function to fill in the repo with dummy data
            Claim temp = new Claim(4, "Car", "description", "$500.00", "4/25/2014", "5/25/2015", true);
            _claimRepo.AddContentToDirectory(temp);
            RunMenu();
        }

        private void RunMenu()
        {

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item: \n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Add a New Claim");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ViewAll();
                        break;
                    case "2":
                        TakeCareOfNext();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ViewAll()
        {
            Console.Clear();
            Console.WriteLine("ClaimID\tType\tDescription\tAmount \tDateOfAccident\tDateOfClaim\tIsValid");
            foreach (Claim claim in _claimRepo.GetAllClaims())
            {
                Console.WriteLine($"{claim.ClaimID}\t{claim.Type}\t{claim.Description}\t{claim.Amount}\t{claim.DateOfAccident}\t{claim.DateOfClaim}\t{claim.IsValid}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void TakeCareOfNext()
        {
            Console.Clear();
            if (_claimRepo.GetAllClaims().Count() > 0)
            {
                Claim nextClaim = _claimRepo.GetAllClaims()[0];
                Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                    $"Type: {nextClaim.Type}\n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Amount: {nextClaim.Amount}\n" +
                    $"DateOfAccident: {nextClaim.DateOfAccident}\n" +
                    $"DateOfClaim: {nextClaim.DateOfClaim}\n" +
                    $"IsValid: {nextClaim.IsValid}");

                bool isHandled = false;

                while (!isHandled)
                {
                    Console.WriteLine("\nDo you want to deal with this claim now?(y/n)");
                    string handleClaim = Console.ReadLine();

                    switch (handleClaim)
                    {
                        case "y":
                            _claimRepo.RemoveFirstClaim();
                            isHandled = true;
                            break;
                        case "n":
                            isHandled = true;
                            break;
                        default:
                            Console.WriteLine("please enter y or n");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no claims to check on.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void AddNewClaim()
        {
            int claimid = 0;
            string type;
            string desc;
            string amount;
            string doa;
            string doc;
            bool valid = false;

            bool numberNeed = true;
            while (numberNeed)
            {
                Console.WriteLine("Enter the claim id: ");
                string userID = Console.ReadLine();
                int id;
                Int32.TryParse(userID, out id);
                //Console.WriteLine(id);
                if (id != 0)
                {
                    claimid = id;
                    numberNeed = false;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }

            Console.WriteLine("Enter the claim type: ");
            type = Console.ReadLine();

            Console.WriteLine("Enter the description: ");
            desc = Console.ReadLine();

            Console.WriteLine("Enter the amount: ");
            amount = Console.ReadLine();

            Console.WriteLine("Enter the date of accident: ");
            doa = Console.ReadLine();

            Console.WriteLine("Enter the date of claim: ");
            doc = Console.ReadLine();

            bool needValid = true;
            while (needValid)
            {
                Console.WriteLine("The vlaim is valid? (t/f)");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "t":
                        valid = true;
                        needValid = false;
                        break;
                    case "f":
                        valid = false;
                        needValid = false;
                        break;
                    default:
                        Console.WriteLine("please tyoe t or f");
                        break;
                }
            }

            Claim newClaim = new Claim(claimid, type, desc, amount, doa, doc, valid);
            _claimRepo.AddContentToDirectory(newClaim);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
