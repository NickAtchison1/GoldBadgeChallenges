using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class Badge
    {
        static int _badgeId = 1;
        public Badge()
        {
            BadgeID = _badgeId++;
        }
       

        public int BadgeID { get; private set; }
       
    }

    public class Door
    {
        static int _doorId = 1;
        public Door()
        {
            DoorID = _doorId++;
        }

        public Door(string doorName)
        {
            DoorName = doorName;
        }
        public int DoorID { get; private set; }
        public string  DoorName { get; set; }
    }

    public class BadgeDoor
    {
        public Badge Badge { get; set; }

        public Door Door { get; set; }
    }
}
