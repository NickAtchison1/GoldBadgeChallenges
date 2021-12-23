using _03_KomodoBadges.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.UI
{
    public  class KomodoBadgesProgramUI
    {
        private readonly IBadgeDoorRepository _badgeDoorRepository;
        private readonly IBadgeRepository _badgeRepository;
        private readonly IDoorRepository _doorRepository;

        public KomodoBadgesProgramUI(IBadgeDoorRepository badgeDoorRepository, IBadgeRepository badgeRepository, IDoorRepository doorRepository)
        {
            _badgeDoorRepository = badgeDoorRepository;
            _badgeRepository = badgeRepository;
            _doorRepository = doorRepository;
        }

        public void Run()
        {
            SeedBadges();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit A badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
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

        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("List All Badges View\n");
            Console.WriteLine("Badge # | Door Access\n" +
                "______________________________________________");
            var badges = _badgeDoorRepository.GetAllBadgeDoors();
            foreach (var badge in badges)
            {
               // Console.WriteLine(String.Format("|{0,2} |{1,2}", badge.Key, badge.Value[0].ToString()));
               Console.WriteLine($"|   {badge.Key}   |   {string.Join(", ", badge.Value.Select(b => b.DoorName))}");
               // Console.WriteLine($"{badge.Key}, {String.Join(", ", badge.Value.Select(i => i.ToString()))}\n");
            }
            WaitForKey();

        }

        private void EditBadge()
        {
            Console.Clear();
            Console.Write("What is the badge number to update? ");
            int requestedBadgeNumber = Convert.ToInt32(Console.ReadLine());
            var badgeItem = _badgeRepository.GetBadgeByID(requestedBadgeNumber);
            //var doorToAddOrRemove = _doorRepository.GetDoorByID(requestedBadgeNumber);
            var badgeToEdit = _badgeDoorRepository.GetAllBadgeDoors();
            //int badgeNumber = Convert.ToInt32(Console.ReadLine());

            foreach (var badge in badgeToEdit)
            {
                if (badge.Key == requestedBadgeNumber)
                {
                    Console.WriteLine($"{badge.Key} has access to {string.Join(", ", badge.Value.Select(b => b.DoorName))}\n");
                }
            }
              
                bool isRunning = true;

                while(isRunning)
                {
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove a door\n" +
                        "2. Add a door");
                    string userChoice = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "1":
                            Console.Write("Which door would you like to remove? ");
                            //  string doorName = Console.ReadLine();
                            int doorId1 = Convert.ToInt32(Console.ReadLine());
                            var doorToRemove = _doorRepository.GetDoorByID(doorId1);
                            
                            _badgeDoorRepository.RemoveDoorFromBadge(requestedBadgeNumber,doorToRemove);
                            Console.WriteLine("Door Removed");
                            isRunning = false;
                            WaitForKey();
                            break;
                        case "2":
                            Console.Write("Which door would you like to Add? ");
                            int doorId = Convert.ToInt32(Console.ReadLine());
                            var doorToAdd = _doorRepository.GetDoorByID(doorId);
                            _badgeDoorRepository.AddDoorToBadge(requestedBadgeNumber, doorToAdd);
                            Console.WriteLine("Door Added");
                            isRunning = false;
                          
                            break;
                        default:
                            Console.WriteLine("Invalid Selection.");
                            WaitForKey();
                            break;
                    }
                    WaitForKey();
                }
            //}
            
            
            

           
        }

        private void AddBadge()
        {
            throw new NotImplementedException();
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedBadges()
        {
            Badge badge1 = new Badge();
            Badge badge2 = new Badge();
            Badge badge3 = new Badge();

            Door door1 = new Door()
            {
                DoorName = "A1"
            };

            Door door2 = new Door()
            {
                DoorName = "A2"
            };

            Door door3 = new Door()
            {
                DoorName = "A3"
            };

            Door door4 = new Door()
            {
                DoorName = "B1"
            };

            Door door5 = new Door()
            {
                DoorName = "B2"
            };

            Door door6 = new Door()
            {
                DoorName = "B3"
            };
            
            List<Door> list = new List<Door>();
            list.Add(door1);
            list.Add(door2);
            list.Add(door3);

            List<Door> list2 = new List<Door>();
            list2.Add(door3);
            list2.Add(door4);
            list2.Add(door5);

            List<Door> list3 = new List<Door>();
            list3.Add(door1);
            list3.Add(door6);


            _badgeDoorRepository.CreateNewBadgeDoor(1, list);
            _badgeDoorRepository.CreateNewBadgeDoor(2, list2);
            _badgeDoorRepository.CreateNewBadgeDoor(3, list3);


        }
    }
}
