using _06_KomodoGreenPlan.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Repositories
{

    public class ElectricCarRepository : IElectricCarRepository
    {
        private readonly List<ElectricCar> _electricCars;
        public ElectricCarRepository()
        {
            _electricCars = new List<ElectricCar>();
        }

        public void InsertElectricCar(ElectricCar electricCar)
        {
            _electricCars.Add(electricCar);
        }

        public List<ElectricCar> GetAllElectricCars()
        {
            return _electricCars;
        }

        public ElectricCar GetElectricCarById(int id)
        {
            return _electricCars.FirstOrDefault(x => x.ElectricCarID == id);
        }

        public void UpdateElectricCar(ElectricCar electricCar)
        {
            var carToUpdate = GetElectricCarById(electricCar.ElectricCarID);
            if (carToUpdate != null)
            {
                carToUpdate.Make = electricCar.Make;
                carToUpdate.Model = electricCar.Model;
                carToUpdate.ModelYear = electricCar.ModelYear;
                carToUpdate.CarValue = electricCar.CarValue;
                carToUpdate.RangePerFullCharge = electricCar.RangePerFullCharge;
                carToUpdate.ChargingTime = electricCar.ChargingTime;
            }
        }

        public void DeleteElectricCar(int electricCarId)
        {
            var carToDelete = _electricCars.FirstOrDefault(x => x.ElectricCarID == electricCarId);
            _electricCars.Remove(carToDelete);
        }
    }
}
