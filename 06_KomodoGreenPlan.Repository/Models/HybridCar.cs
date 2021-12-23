using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Models
{
    public class HybridCar : ICar
    {
        static int _hybridCarID = 1;
        public HybridCar()
        {
            HybridCarID = _hybridCarID++;
        }
        public HybridCar(string make, string model, int modelYear, decimal carValue, double mpg, double fuelTankCapcity, double rangePerFullCharge, double chargingTime)
        {
            Make = make;
            Model = model;
            ModelYear = modelYear;
            CarValue = carValue;
            MPG = mpg;
            FuelTankCapacity = fuelTankCapcity;
            RangePerFullCharge = rangePerFullCharge;
            ChargingTime = chargingTime;
        }
        public int HybridCarID { get; private set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public int ModelYear { get; set; }

        public decimal CarValue { get; set; }

        public double MPG { get; set; }

        public double FuelTankCapacity { get; set; }

        public double RangePerFullCharge { get; set; }

        public double ChargingTime { get; set; }
    }
}
