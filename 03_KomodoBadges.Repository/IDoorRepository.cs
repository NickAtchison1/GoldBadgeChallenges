using System.Collections.Generic;

namespace _03_KomodoBadges.Repository
{
    public interface IDoorRepository
    {
        void CreateDoor(Door door);
        void DeleteMenuItem(int doorID);
        List<Door> GetAlldoors();
        Door GetDoorByID(int id);
    }
}