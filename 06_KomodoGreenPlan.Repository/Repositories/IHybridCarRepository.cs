using _06_KomodoGreenPlan.Repository.Models;
using System.Collections.Generic;

namespace _06_KomodoGreenPlan.Repository.Repositories
{
    public interface IHybridCarRepository
    {
        void DeleteHybridCar(int hybridCarId);
        List<HybridCar> GetAllHybridCars();
        HybridCar GetHybridCarById(int id);
        void InsertHybridCar(HybridCar hybridCar);
        void UpdateHybridCar(HybridCar hybridCar);
    }
}