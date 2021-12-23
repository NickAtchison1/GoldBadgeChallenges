using _06_KomodoGreenPlan.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Repositories
{
    public class HybridCarRepository : IHybridCarRepository
    {
        private readonly List<HybridCar> _hybridCars;

        public HybridCarRepository()
        {
            _hybridCars = new List<HybridCar>();
        }

        public void InsertHybridCar(HybridCar hybridCar)
        {
            _hybridCars.Add(hybridCar);
        }

        public List<HybridCar> GetAllHybridCars()
        {
            return _hybridCars;
        }

        public HybridCar GetHybridCarById(int id)
        {
            return _hybridCars.FirstOrDefault(x => x.HybridCarID == id);
        }

        public void UpdateHybridCar(HybridCar hybridCar)
        {
            var carToUpdate = GetHybridCarById(hybridCar.HybridCarID);
            if (carToUpdate != null)
            {
                carToUpdate.Make = hybridCar.Make;
                carToUpdate.Model = hybridCar.Model;
                carToUpdate.ModelYear = hybridCar.ModelYear;
                carToUpdate.CarValue = hybridCar.CarValue;
                carToUpdate.MPG = hybridCar.MPG;
                carToUpdate.FuelTankCapacity = hybridCar.FuelTankCapacity;
                carToUpdate.RangePerFullCharge = hybridCar.RangePerFullCharge;
                carToUpdate.ChargingTime = hybridCar.ChargingTime;
            }
            else
            {
                Console.WriteLine("Car Not Found");
            }
        }

        public void DeleteHybridCar(int hybridCarId)
        {
            var carToDelete = _hybridCars.FirstOrDefault(x => x.HybridCarID == hybridCarId);
            _hybridCars.Remove(carToDelete);
        }
    }
}
