using _03_KomodoBadges.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.UI
{
    public  class Program
    {
        static void Main(string[] args)    
        {
            BadgeDoorRepository badgeDoorRepository = new BadgeDoorRepository();
            BadgeRepository badgeRepository = new BadgeRepository();
            DoorRepository doorRepository = new DoorRepository();

           
            KomodoBadgesProgramUI ui = new KomodoBadgesProgramUI(badgeDoorRepository, badgeRepository, doorRepository);
            ui.Run();
        }
    }
}
