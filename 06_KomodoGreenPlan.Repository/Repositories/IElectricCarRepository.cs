using _06_KomodoGreenPlan.Repository.Models;
using System.Collections.Generic;

namespace _06_KomodoGreenPlan.Repository.Repositories
{
    public interface IElectricCarRepository
    {
        void DeleteElectricCar(int electricCarId);
        List<ElectricCar> GetAllElectricCars();
        ElectricCar GetElectricCarById(int id);
        void InsertElectricCar(ElectricCar electricCar);
        void UpdateElectricCar(ElectricCar electricCar);
    }
}