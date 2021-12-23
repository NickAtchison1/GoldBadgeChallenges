using _06_KomodoGreenPlan.Repository.Models;
using _06_KomodoGreenPlan.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.UI
{
    public class KomodoGreenPlanProgramUI
    {
        private readonly IElectricCarRepository _electricCarRepository;
        private readonly IHybridCarRepository _hybridCarRepository;
        private readonly IGasCarRepository _gasCarRepository;
        public KomodoGreenPlanProgramUI(IElectricCarRepository electricCarRepository, IHybridCarRepository hybridCarRepository, IGasCarRepository gasCarRepository)
        {
            _electricCarRepository = electricCarRepository;
            _hybridCarRepository = hybridCarRepository;
            _gasCarRepository = gasCarRepository;
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Komodo Green Plan Cars\n" +
                    "\n" +
                    "1. Electric Cars\n" +
                    "2. Hybrid Cars\n" +
                    "3. Gas Cars\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ElectricCarsMenu();
                        break;
                    case "2":
                        HybridCarsMenu();
                        break;
                    case "3":
                        GasCarsMenu();
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

        private void GasCarsMenu()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Komodo Green Plan Gas Cars\n" +
                    "\n" +
                    "1. View All Gas Cars\n" +
                    "2. View Specific Car\n" +
                    "3. Add Gas Car\n" +
                    "4. Update Car\n" +
                    "5. Delete Car\n" +
                    "6. Main Menu");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewListOfGasCars();
                        break;
                    case "2":
                        ViewGasCarDetail();
                        break;
                    case "3":
                        AddGasCar();
                        break;
                    case "4":
                        UpdateGasCar();
                        break;
                    case "5":
                        DeleteGasCar();
                        break;
                    case "6":
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

        private void UpdateGasCar()
        {
            Console.Clear();
            Console.WriteLine("Gas Car Update View");
            Console.Write("Enter the ID of the Car you would like to update: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _gasCarRepository.GetGasCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.GasCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"MPG: {carToView.MPG}\n" +
                $"Fuel Tank Capacity(gal): {carToView.FuelTankCapacity}\n");
            WaitForKey();

            Console.WriteLine("Please make changes to this car. Please fill in the original data on the field if no changes are needed\n");
            Console.Write("Make? ");
            carToView.Make = Console.ReadLine();
            Console.Write("Model? ");
            carToView.Model = Console.ReadLine();
            Console.Write("Year? ");
            carToView.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value? ");
            carToView.CarValue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("MPG? ");
            carToView.MPG = Convert.ToDouble(Console.ReadLine());
            Console.Write("Fuel Tank Capcity (In Gallons)? ");
            carToView.FuelTankCapacity = Convert.ToDouble(Console.ReadLine());

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Updates have been applied. Do you want to save your changes? (y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Saving Changes!\n");
                        _gasCarRepository.UpdateGasCar(carToView);
                        isRunning = false;

                        break;
                    case "n":
                        Console.WriteLine("Update cancelled. Returning to the Gas Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();
            }
        }

        private void DeleteGasCar()
        {
            Console.Clear();
            Console.WriteLine("Delete Hybrid Car View\n");
            Console.Write("Enter the ID of the car you would like to delete: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _gasCarRepository.GetGasCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.GasCarID}\n" +
               $"Make: {carToView.Make} \n" +
               $"Model {carToView.Model}\n" +
               $"Year: {carToView.ModelYear}\n" +
               $"Value: {carToView.CarValue}\n" +
               $"MPG: {carToView.MPG}\n" +
               $"Fuel Tank Capacity(gal): {carToView.FuelTankCapacity}\n");
               
            // WaitForKey();
            Console.WriteLine("Danger Zone - Delete Cannot  Be Undone!");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to delete this car(y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Car has been Deleted!\n");
                        _gasCarRepository.DeleteGasCar(carId);
                        isRunning = false;
                        break;
                    case "n":
                        Console.WriteLine("Car has not been deleted. Returning to the Gas Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();
            }
        }

        private void AddGasCar()
        {
            Console.Clear();
            Console.WriteLine("Add Gas Car\n");
            GasCar gc = new GasCar();
            Console.Write("Make? ");
            gc.Make = Console.ReadLine();
            Console.Write("Model? ");
            gc.Model = Console.ReadLine();
            Console.Write("Year? ");
            gc.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value? ");
            gc.CarValue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("MPG? ");
            gc.MPG = Convert.ToDouble(Console.ReadLine());
            Console.Write("Fuel Tank Capcity (In Gallons)? ");
            gc.FuelTankCapacity = Convert.ToDouble(Console.ReadLine());
            
            _gasCarRepository.InsertGasCar(gc);
            
            WaitForKey();
        }

        private void ViewGasCarDetail()
        {
            Console.Clear();
            Console.WriteLine("Gas Car Detail View");
            Console.Write("Enter the ID of the Car you would like to view: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _gasCarRepository.GetGasCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.GasCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"MPG: {carToView.MPG}\n" +
                $"Fuel Tank Capacity(gal): {carToView.FuelTankCapacity}\n");
               
            WaitForKey();
        }

        private void ViewListOfGasCars()
        {
            Console.Clear();
            Console.WriteLine("Gas Cars List");
            Console.WriteLine("\n");
            Console.WriteLine("ID | MAKE | MODEL   | YEAR | VALUE | MPG | FUEL TANK CAPCITY (GAL)");
            var allGasCars = _gasCarRepository.GetAllGasCars();
            foreach (var cars in allGasCars)
            {
                Console.WriteLine($"{cars.GasCarID} | " +
                    $"{cars.Make} | " +
                    $"{cars.Model} | " +
                    $"{cars.ModelYear} | " +
                    $"{cars.CarValue} | " +
                    $"{cars.MPG} | " +
                    $"{cars.FuelTankCapacity}\n");
                   
            }
            WaitForKey();
        }

        private void HybridCarsMenu()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Komodo Green Plan Hybrid Cars\n" +
                    "\n" +
                    "1. View All Hybrid Cars\n" +
                    "2. View Specific Car\n" +
                    "3. Add Hybrid Car\n" +
                    "4. Update Car\n" +
                    "5. Delete Car\n" +
                    "6. Main Menu");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewListOfHybridCars();
                        break;
                    case "2":
                        ViewHybridCarDetail();
                        break;
                    case "3":
                        AddHybridCar();
                        break;
                    case "4":
                        UpdateHybridCar();
                        break;
                    case "5":
                        DeleteHybridCar();
                        break;
                    case "6":
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

        private void DeleteHybridCar()
        {
            Console.Clear();
            Console.WriteLine("Delete Hybrid Car View\n");
            Console.Write("Enter the ID of the car you would like to delete: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _hybridCarRepository.GetHybridCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.HybridCarID}\n" +
               $"Make: {carToView.Make} \n" +
               $"Model {carToView.Model}\n" +
               $"Year: {carToView.ModelYear}\n" +
               $"Value: {carToView.CarValue}\n" +
               $"MPG: {carToView.MPG}\n" +
               $"Fuel Tank Capacity(gal): {carToView.FuelTankCapacity}\n" +
               $"Range (In Miles): {carToView.RangePerFullCharge}\n" +
               $"Full Charge Time (In Hours): {carToView.ChargingTime}\n");
           // WaitForKey();
            Console.WriteLine("Danger Zone - Delete Cannot  Be Undone!");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to delete this car(y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Car has been Deleted!\n");
                        _hybridCarRepository.DeleteHybridCar(carId);
                        isRunning = false;
                        break;
                    case "n":
                        Console.WriteLine("Car has not been deleted. Returning to the Hybrid Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();
            }
        }

        private void UpdateHybridCar()
        {
            Console.Clear();
            Console.WriteLine("Hybrid Car Update View");
            Console.Write("Enter the ID of the Car you would like to update: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _hybridCarRepository.GetHybridCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.HybridCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"MPG: {carToView.MPG}\n" +
                $"Fuel Tank Capacity(gal): {carToView.FuelTankCapacity}\n" +
                $"Range (In Miles): {carToView.RangePerFullCharge}\n" +
                $"Full Charge Time (In Hours): {carToView.ChargingTime}\n");
            WaitForKey();

            Console.WriteLine("Please make changes to this car. Please fill in the original data on the field if no changes are needed\n");
            Console.Write("Make? ");
            carToView.Make = Console.ReadLine();
            Console.Write("Model? ");
            carToView.Model = Console.ReadLine();
            Console.Write("Year? ");
            carToView.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value? ");
            carToView.CarValue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("MPG? ");
            carToView.MPG = Convert.ToDouble(Console.ReadLine());
            Console.Write("Fuel Tank Capcity (In Gallons)? ");
            carToView.FuelTankCapacity = Convert.ToDouble(Console.ReadLine());
            Console.Write("Range (In Miles)? ");
            carToView.RangePerFullCharge = Convert.ToDouble(Console.ReadLine());
            Console.Write("Charging Time (In hours? ");
            carToView.ChargingTime = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n");
           
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Updates have been applied. Do you want to save your changes? (y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Saving Changes!\n");
                        _hybridCarRepository.UpdateHybridCar(carToView);
                        isRunning = false;

                        break;
                    case "n":
                        Console.WriteLine("Update cancelled. Returning to the Hybrid Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();
            }
        }

        private void AddHybridCar()
        {
            Console.Clear();
            Console.WriteLine("Add Electric Car\n");
            HybridCar hc = new HybridCar();
            Console.Write("Make? ");
            hc.Make = Console.ReadLine();
            Console.Write("Model? ");
            hc.Model = Console.ReadLine();
            Console.Write("Year? ");
            hc.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value? ");
            hc.CarValue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("MPG? ");
            hc.MPG = Convert.ToDouble(Console.ReadLine());
            Console.Write("Fuel Tank Capcity (In Gallons)? ");
            hc.FuelTankCapacity = Convert.ToDouble(Console.ReadLine());
            Console.Write("Range (In Miles)? ");
            hc.RangePerFullCharge = Convert.ToDouble(Console.ReadLine());
            Console.Write("Charging Time (In hours? ");
            hc.ChargingTime = Convert.ToDouble(Console.ReadLine());

            _hybridCarRepository.InsertHybridCar(hc);
            WaitForKey();
        }

        private void ViewHybridCarDetail()
        {
            Console.Clear();
            Console.WriteLine("Hybrid Car Detail View");
            Console.Write("Enter the ID of the Car you would like to view: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _hybridCarRepository.GetHybridCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.HybridCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"MPG: {carToView.MPG}\n" +
                $"Fuel Tank Capacity(gal): {carToView.FuelTankCapacity}\n" +
                $"Range (In Miles): {carToView.RangePerFullCharge}\n" +
                $"Full Charge Time (In Hours): {carToView.ChargingTime}\n");
            WaitForKey();
        }

        private void ViewListOfHybridCars()
        {
            Console.Clear();
            Console.WriteLine("Hybrid Cars List");
            Console.WriteLine("\n");
            Console.WriteLine("ID | MAKE | MODEL   | YEAR | VALUE | MPG | FUEL TANK CAPCITY (GAL) | RANGE IN MILES | FULL CHARGE TIME (IN HOURS)");
            var allHybridCars = _hybridCarRepository.GetAllHybridCars();
            foreach (var cars in allHybridCars)
            {
                Console.WriteLine($"{cars.HybridCarID} | " +
                    $"{cars.Make} | " +
                    $"{cars.Model} | " +
                    $"{cars.ModelYear} | " +
                    $"{cars.CarValue} | " +
                    $"{cars.MPG} | " +
                    $"{cars.FuelTankCapacity} | " +
                    $"{cars.RangePerFullCharge} | " +
                    $"{cars.ChargingTime}\n");
            }
            WaitForKey();
        }

        private void ElectricCarsMenu()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Komodo Green Plan Electric Cars\n" +
                    "\n" +
                    "1. View All Electric Cars\n" +
                    "2. View Specific Car\n" +
                    "3. Add Electric Car\n" +
                    "4. Update Car\n" +
                    "5. Delete Car\n" +
                    "6. Main Menu");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewListOfElectricCars();
                        break;
                    case "2":
                        ViewElectricCarDetail();
                        break;
                    case "3":
                        AddElectricCar();
                        break;
                    case "4":
                        UpdateElectricCar();
                        break;
                    case "5":
                        DeleteElectricCar();
                        break;
                    case "6":
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

     

        private void AddElectricCar()
        {
            Console.Clear ();
            Console.WriteLine("Add Electric Car\n");
            ElectricCar ec = new ElectricCar();
            Console.Write("Make? ");
            ec.Make = Console.ReadLine();
            Console.Write("Model? ");
            ec.Model = Console.ReadLine();
            Console.Write("Year? ");
            ec.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value? ");
            ec.CarValue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Range (In Miles)? ");
            ec.RangePerFullCharge = Convert.ToDouble(Console.ReadLine());
            Console.Write("Charging Time (In hours? ");
            ec.ChargingTime = Convert.ToDouble(Console.ReadLine());

            _electricCarRepository.InsertElectricCar(ec);
            WaitForKey();
        }

        private void DeleteElectricCar()
        {
            Console.Clear();
            Console.WriteLine("Delete Electric Car View\n");
            Console.Write("Enter the ID of the car you would like to delete: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _electricCarRepository.GetElectricCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.ElectricCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"Range (In Miles): {carToView.RangePerFullCharge}\n" +
                $"Full Charge Time (In Hours): {carToView.ChargingTime}\n");
            Console.WriteLine("Danger Zone - Delete Cannot  Be Undone!");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to delete this car(y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Car has been Deleted!\n");
                        _electricCarRepository.DeleteElectricCar(carId);
                        isRunning = false;

                        break;
                    case "n":
                        Console.WriteLine("Car has not been deleted. Returning to the Electric Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();
            }
        }

        private void UpdateElectricCar()
        {
            Console.Clear();
            Console.WriteLine("Electric Car Update View");
            Console.Write("Enter the ID of the Car you would like to update: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _electricCarRepository.GetElectricCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.ElectricCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"Range (In Miles): {carToView.RangePerFullCharge}\n" +
                $"Full Charge Time (In Hours): {carToView.ChargingTime}\n");
            WaitForKey();

            Console.WriteLine("Please make changes to this car. Please fill in the original data on the field if no changes are needed\n");
            Console.Write("Make? ");
            carToView.Make = Console.ReadLine();
            Console.Write("Model? ");
            carToView.Model = Console.ReadLine();
            Console.Write("Year? ");
            carToView.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value? ");
            carToView.CarValue = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Range (In Miles)? ");
            carToView.RangePerFullCharge = Convert.ToDouble(Console.ReadLine());
            Console.Write("Charging Time (In hours? ");
            carToView.ChargingTime = Convert.ToDouble(Console.ReadLine());


            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Updates have been applied. Do you want to save your changes? (y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Saving Changes!\n");
                        _electricCarRepository.UpdateElectricCar(carToView);
                        isRunning = false;

                        break;
                    case "n":
                        Console.WriteLine("Update cancelled. Returning to the Electric Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();
            }
        }

        private void ViewElectricCarDetail()
        {
            Console.Clear();
            Console.WriteLine("Electric Car Detail View");
            Console.Write("Enter the ID of the Car you would like to view: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var carToView = _electricCarRepository.GetElectricCarById(carId);
            Console.WriteLine("\n");
            Console.WriteLine($"ID: {carToView.ElectricCarID}\n" +
                $"Make: {carToView.Make} \n" +
                $"Model {carToView.Model}\n" +
                $"Year: {carToView.ModelYear}\n" +
                $"Value: {carToView.CarValue}\n" +
                $"Range (In Miles): {carToView.RangePerFullCharge}\n" +
                $"Full Charge Time (In Hours): {carToView.ChargingTime}\n");
            WaitForKey();
        }
           

      
        private void ViewListOfElectricCars()
        {

            Console.Clear();
            Console.WriteLine("Electric Cars List");
            Console.WriteLine("\n");
            Console.WriteLine("ID | MAKE | MODEL   | YEAR | VALUE | RANGE IN MILES | FULL CHARGE TIME (IN HOURS)");
            var allElectricCars = _electricCarRepository.GetAllElectricCars();
            foreach (var cars in allElectricCars)
            {
                Console.WriteLine($"{cars.ElectricCarID} | " +
                    $"{cars.Make} | " +
                    $"{cars.Model} | " +
                    $"{cars.ModelYear} | " +
                    $"{cars.CarValue} | " +
                    $"{cars.RangePerFullCharge} | " +
                    $"{cars.ChargingTime}\n");
            }
           
            WaitForKey();
        }
           

       private void Seed()
        {
            ElectricCar electricCar = new ElectricCar()
            {
                Make = "Tesla",
                Model = "Model 3",
                ModelYear = 2021,
                CarValue =  50000.00m,
                RangePerFullCharge = 358.00,
                ChargingTime = 8.0

            };

            ElectricCar electricCar2 = new ElectricCar()
            {
                Make = "Tesla",
                Model = "Model S",
                ModelYear = 2022,
                CarValue = 90000.00m,
                RangePerFullCharge = 396.00,
                ChargingTime = 8.0

            };

            HybridCar hybridCar = new HybridCar()
            {
                Make = "Honda",
                Model = "Accord Hybrid",
                ModelYear = 2021,
                CarValue = 27500.00m,
                MPG = 44,
                FuelTankCapacity = 12.8,
                RangePerFullCharge = 47,
                ChargingTime = 2.5

            };

            HybridCar hybridCar2 = new HybridCar()
            {
                Make = "Toyota",
                Model = "Prius",
                ModelYear = 2021,
                CarValue = 25500.00m,
                MPG = 50,
                FuelTankCapacity = 11.3,
                RangePerFullCharge = 25,
                ChargingTime = 2.5

            };

            GasCar gasCar = new GasCar()
            {
                Make = "Honda",
                Model = "Accord Sport 2.0T",
                ModelYear = 2021,
                CarValue = 32000.00m,
                MPG = 36,
                FuelTankCapacity = 12.5
            };

            GasCar gasCar2 = new GasCar()
            {
                Make = "Hyundai",
                Model = "Sonata",
                ModelYear = 2022,
                CarValue = 27000.00m,
                MPG = 36,
                FuelTankCapacity = 12.5
            };


            _electricCarRepository.InsertElectricCar(electricCar);
            _electricCarRepository.InsertElectricCar(electricCar2);
            _hybridCarRepository.InsertHybridCar(hybridCar);
            _hybridCarRepository.InsertHybridCar(hybridCar2);
            _gasCarRepository.InsertGasCar(gasCar);
            _gasCarRepository.InsertGasCar(gasCar2);
        }
            
}
    }
