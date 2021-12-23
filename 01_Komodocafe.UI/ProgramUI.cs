using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komodocafe.UI
{
    public  class ProgramUI
    {
        private readonly IMenuItemRepository _menuItemRepo;

        public ProgramUI(IMenuItemRepository menuItemRepo)
        {
            _menuItemRepo = menuItemRepo;
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe Menu\n" +
                    "1. Add A Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. Delete A Menu Item\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
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

        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("DELETE MEAL ITEM SCREEN\n");
            Console.Write("Please Enter Meal Number To Delete\n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            var itemToDelete = _menuItemRepo.GetMenuItemByMenuNumber(userInput);
            Console.WriteLine($"Menu Number: {itemToDelete.MealNumber}\n" +
                $"Menu Item: {itemToDelete.MealName}\n");

            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("Are you sure you want to delete this item?\n" +
               "Press 1 for Yes. Press 2 for No\n" +
                "1. Yes\n" +
                "2. No\n");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine($"Menu Number: {itemToDelete.MealNumber}\n" +
                $"Menu Item: {itemToDelete.MealName}\n" +
                $"Is being removed from the Menu.");
                        _menuItemRepo.DeleteMenuItem(userInput);

                        break;
                    case "2":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;
                        
                }
            }
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            Console.WriteLine("Showing All Komodo Cafe Menu Items");
            Console.WriteLine("\n");
            var allMenuItems = _menuItemRepo.GetAllMenuItems();
            foreach (var menuItem in allMenuItems)
            {
                Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n" +
                    $"Meal Name: {menuItem.MealName}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Price: {menuItem.Price}\n" +
                    $"Ingredients: {String.Join(", ",menuItem.Ingredients.Select(i => i.ToString()))}\n");
              



            }
            
            WaitForKey();
        }

        private void AddMenuItem()
        {
            Console.Clear ();
            MenuItem menuItem = new MenuItem();
       
            Console.Write("Please enter the meal name: ");
            menuItem.MealName = Console.ReadLine();

            Console.Write("Please enter a description of the meal: ");
            menuItem.Description = Console.ReadLine();

            Console.WriteLine("Indgredients: \n");
            menuItem.Ingredients.Add(Console.ReadLine());

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Add More Ingredients: " +
               "Press 1 for Yes. Press 2 for No\n" +
                "1. Yes\n" +
                "2. No\n");
                string addMoreIngredients = Console.ReadLine();
                switch (addMoreIngredients)
                {
                    case "1":
                        Console.WriteLine("Indgredient: \n");
                        menuItem.Ingredients.Add(Console.ReadLine());
                       
                        break;
                    case "2":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;
                        
                }
            }

            Console.Write("Please enter a price for the meal: ");
            menuItem.Price = Convert.ToDecimal (Console.ReadLine());
            Console.Write("\n");
            _menuItemRepo.CreateMenuItem(menuItem);
            Console.WriteLine($"Menu Item {menuItem.MealName} has been created.\n" +
                $"The auto-assigned Meal Number is {menuItem.MealNumber}.\n" +
                $"Please Select 'View All Menu Items' from the Main Menu to see more information.\n");
               
            WaitForKey();

        }

        private void Seed()
        {
            MenuItem hamBurger = new MenuItem()
            {
                MealName = "Hamburger",
                Description = "A hamburger",
                Ingredients = {"Beef Patty",  "Lettuce", "Tomato", "Beef Patty", "Pickle" },
                Price = 4.99m

            };
            MenuItem cheeseBurger = new MenuItem()
            {
                MealName = "Hamburger",
                Description = "A cheeseburger",
                Ingredients = {"Beef Patty", "Cheese", "Lettuce", "Tomato", "Beef Patty", "Pickle" },
                Price = 5.99m

            };
            _menuItemRepo.CreateMenuItem(hamBurger);
            _menuItemRepo.CreateMenuItem(cheeseBurger);

        }
    }
}
