using _06_KomodoGreenPlan.Repository.Models;
using System.Collections.Generic;

namespace _06_KomodoGreenPlan.Repository.Repositories
{
    public interface IGasCarRepository
    {
        void DeleteGasCar(int gasCarId);
        List<GasCar> GetAllGasCars();
        GasCar GetGasCarById(int id);
        void InsertGasCar(GasCar gasCar);
        void UpdateGasCar(GasCar gasCar);
    }
}