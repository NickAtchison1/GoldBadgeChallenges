using _02_KomodoClaims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims.UI
{
    public  class KomodoClaimsProgramUI
    {
        private readonly IClaimsRepository _claimsRepo;

        public KomodoClaimsProgramUI(IClaimsRepository claimsRepo)
        {
            _claimsRepo = claimsRepo;
        }

        public void Run()
        {
            SeedClaims();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("KOMODO CLAIMS\n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claims\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;
                }
                Console.Clear();
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claims claims = new Claims();
            Console.WriteLine("What is the Claim Type? ");
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("1. Car\n" +
                    "2. Home\n" +
                    "3. Theft\n");
                string selectedChoice = Console.ReadLine();
                switch (selectedChoice)
                {
                    case "1":
                        claims.ClaimType = ClaimType.Car;
                       isRunning = false;
                        break;
                    case "2":
                        claims.ClaimType = ClaimType.Home;
                       isRunning = false;
                        break;
                    case"3":
                        claims.ClaimType = ClaimType.Theft;
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;
                }
            }

            Console.WriteLine("Please enter a description about the claim");
            claims.Desription = Console.ReadLine();

            Console.WriteLine("What is the amount of the claim?");
            claims.ClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please enter the date of the incident (e.g. yyyy, mm, dd)");
            //https://stackoverflow.com/questions/42075554/inputing-a-date-from-console-in-c-sharp
            claims.DateOfIncident = DateTime.Parse(Console.ReadLine());

            _claimsRepo.CreateNewClaim(claims);
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("SHOWING NEXT CLAIM IN QUEUE");
            var nextClaim = _claimsRepo.ShowNextClaimInLine();
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Desription}\n" +
                $"Amount: {nextClaim.ClaimAmount}\n" +
                $"Date Of Incident: {nextClaim.DateOfIncident}\n" +
                $"Date Of Claim: {nextClaim.DateOfClaim}\n" +
                $"Is Valid: {nextClaim.IsValid}\n");

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to deal with this claim now(y/n)?\n");
               
                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("You have chosen to handle this claim. It is being removed from the queue\n");
                        _claimsRepo.DealWithThisClaimNow();
                        isRunning = false;
                        
                        break;
                    case "n":
                        Console.WriteLine("You have chosen not to handle this claim. Returning to the Main Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;

                }
            }
            WaitForKey();
            
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("SHOWING ALL CLAIMS\n");
            var allClaims = _claimsRepo.ViewAllClaims();


            var columnHeaders = _claimsRepo.GetProperties(_claimsRepo.ShowNextClaimInLine());
            Console.WriteLine(columnHeaders);
            Console.WriteLine("_____________________________________________________________________________________________________________");
            foreach (var claim in allClaims)
            {
                Console.WriteLine(
                    String.Format(
                        "|{0,6} |{1,6} |{2,6}  |{3,6}  |{4,6}  |{5,6}  |{6,6}",
                        claim.ClaimID,
                        claim.ClaimType,
                        claim.Desription,
                        claim.ClaimAmount,
                        claim.DateOfIncident,
                        claim.DateOfClaim,
                        claim.IsValid));

            }
            WaitForKey();
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

            private void SeedClaims()
        {
            Claims claim1 = new Claims()
            {
                ClaimType = ClaimType.Car,
                Desription = "Car accident on 465.",
                ClaimAmount = 400.00m,
                DateOfIncident = new DateTime(2021, 12, 10)

            };

            Claims claim2 = new Claims()
            {
                ClaimType = ClaimType.Home,
                Desription = "house fire in kitchen.",
                ClaimAmount = 4000.00m,
                DateOfIncident = new DateTime(2021, 12, 10)

            };

            Claims claim3 = new Claims()
            {
                ClaimType = ClaimType.Theft,
                Desription = "Stolen pancakes.",
                ClaimAmount = 4.00m,
                DateOfIncident = new DateTime(2021, 9, 10)

            };
            _claimsRepo.CreateNewClaim(claim1);
            _claimsRepo.CreateNewClaim(claim2);
            _claimsRepo.CreateNewClaim(claim3);
        }

       
    }
}
