using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Models
{
    public class GasCar : ICar
    {
        static int _gasCarID = 1;

        public GasCar()
        {
            GasCarID = _gasCarID++;
        }
        public GasCar(string make, string model, int modelYear, decimal carvalue, double mpg, double fuelTankCapacity)
        {
            Make = make;
            Model = model;
            ModelYear = modelYear;
            CarValue = carvalue;
            MPG = mpg;
            FuelTankCapacity = fuelTankCapacity;
        }
        public int GasCarID { get; private set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public int ModelYear { get; set; }

        public decimal CarValue { get; set; }

        public double MPG { get; set; }

        public double FuelTankCapacity { get; set; }
    }
}
