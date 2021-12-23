using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class DoorRepository : IDoorRepository
    {
        private readonly List<Door> _doors;
        public DoorRepository()
        {
            _doors = new List<Door>();
        }

        public void CreateDoor(Door door)
        {


            _doors.Add(door);
        }

        public List<Door> GetAlldoors()
        {
            return _doors;
        }


        public Door GetDoorByID(int id)
        {
            var door = _doors.FirstOrDefault(d => d.DoorID == id);
            return door;
        }
        public void DeleteMenuItem(int doorID)
        {
            var doorToDelete = GetDoorByID(doorID);
            if (doorToDelete != null)
            {
                _doors.Remove(doorToDelete);
            }
            else
            {
                Console.WriteLine("Door does not exist.");
            }

        }
    }
}
