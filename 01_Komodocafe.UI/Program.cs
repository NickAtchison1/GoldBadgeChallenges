using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Komodocafe.UI
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            IMenuItemRepository repository = new MenuItemRepository();
            ProgramUI ui = new ProgramUI(repository);
            ui.Run();
        }
    }
}
