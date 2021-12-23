using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Models
{
    public class ElectricCar : ICar
    {
        static int _electricCarID = 1;
        public ElectricCar()
        {
            ElectricCarID = _electricCarID++;
        }

        public ElectricCar(string make, string model, int modelYear, decimal carValue, double rangePerFullCharge, double chargingTime)
        {
            Make = make;
            Model = model;
            ModelYear = modelYear;
            CarValue = carValue;
            RangePerFullCharge = rangePerFullCharge;
            ChargingTime = chargingTime;
        }
        public int ElectricCarID { get; private set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public int ModelYear { get; set; }

        public decimal CarValue { get; set; }

        public double RangePerFullCharge { get; set; }

        public double ChargingTime { get; set; }
    }
}
