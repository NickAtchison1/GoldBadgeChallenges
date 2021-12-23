using _02_KomodoClaims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClaimsRepository claimsRepository = new ClaimsRepository();
            KomodoClaimsProgramUI ui = new KomodoClaimsProgramUI(claimsRepository);
            ui.Run();
        }
    }
}
