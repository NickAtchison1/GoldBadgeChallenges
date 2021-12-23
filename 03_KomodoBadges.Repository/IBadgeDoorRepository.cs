using System.Collections.Generic;

namespace _03_KomodoBadges.Repository
{
    public interface IBadgeDoorRepository
    {
        void AddDoorToBadge(int id, Door doors);
        void CreateNewBadgeDoor(int id, List<Door> doors);
        Dictionary<int, List<Door>> GetAllBadgeDoors();
        void RemoveDoorFromBadge(int id, Door door);
    }
}