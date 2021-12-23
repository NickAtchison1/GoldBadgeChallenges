using _06_KomodoGreenPlan.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Repositories
{
    public class CarRepository
    {
        private readonly List<ElectricCar> _electricCars;
        private readonly List<HybridCar> _hybridCars;
        private readonly List<GasCar> _gasCars;

        public CarRepository()
        {
            _electricCars = new List<ElectricCar>();
            _hybridCars = new List<HybridCar>();
        }
    }
}
