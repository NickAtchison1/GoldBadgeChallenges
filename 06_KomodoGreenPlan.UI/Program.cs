using _06_KomodoGreenPlan.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.UI
{
    public  class Program
    {
        static void Main(string[] args)
        {
            ElectricCarRepository electricCarRepository = new ElectricCarRepository();
            HybridCarRepository hybridCarRepository = new HybridCarRepository();
            GasCarRepository gasCarRepository = new GasCarRepository();
            KomodoGreenPlanProgramUI ui = new KomodoGreenPlanProgramUI(electricCarRepository, hybridCarRepository, gasCarRepository);
            ui.Run();
        }
    }
}
