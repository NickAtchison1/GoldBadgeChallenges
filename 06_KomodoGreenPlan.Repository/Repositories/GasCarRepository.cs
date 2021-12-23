using _06_KomodoGreenPlan.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Repositories
{
    public class GasCarRepository : IGasCarRepository
    {
        private readonly List<GasCar> _gasCars;

        public GasCarRepository()
        {
            _gasCars = new List<GasCar>();
        }

        public void InsertGasCar(GasCar gasCar)
        {
            _gasCars.Add(gasCar);
        }

        public List<GasCar> GetAllGasCars()
        {
            return _gasCars;
        }

        public GasCar GetGasCarById(int id)
        {
            return _gasCars.FirstOrDefault(x => x.GasCarID == id);
        }

        public void UpdateGasCar( GasCar gasCar)
        {
            var carToUpdate = GetGasCarById(gasCar.GasCarID);
            if (carToUpdate != null)
            {
                carToUpdate.Make = gasCar.Make;
                carToUpdate.Model = gasCar.Model;
                carToUpdate.ModelYear = gasCar.ModelYear;
                carToUpdate.CarValue = gasCar.CarValue;
                carToUpdate.MPG = gasCar.MPG;
                carToUpdate.FuelTankCapacity = gasCar.FuelTankCapacity;

            }
            else
            {
                Console.WriteLine("Car Not Found");
            }
        }

        public void DeleteGasCar(int gasCarId)
        {
            var carToDelete = _gasCars.FirstOrDefault(x => x.GasCarID == gasCarId);
            _gasCars.Remove(carToDelete);
        }
    }
}
