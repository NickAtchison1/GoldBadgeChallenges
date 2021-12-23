using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class BadgeDoorRepository : IBadgeDoorRepository
    {
        private readonly Dictionary<int, List<Door>> _badgeDoor;
        // private readonly IDoorRepository _doorRepository;
        private readonly List<Door> _doors;

        public BadgeDoorRepository()
        {
            _badgeDoor = new Dictionary<int, List<Door>>();
            //  _badge = new List<Badge>();
            _doors = new List<Door>();
           // _doorRepository = doorRepository;

        }

        public void CreateNewBadgeDoor(int id, List<Door> doors)
        {
            //var doorList = _doors.Select(door => door.DoorName).ToList();
            //var badgeID = _badge.Select(x => x.BadgeID).FirstOrDefault(y => y.Equals(id));
            _badgeDoor.Add(id, doors);
        }

        public Dictionary<int, List<Door>> GetAllBadgeDoors()
        {
            return _badgeDoor;
        }

        //public Dictionary<Badge, List<Door>> GetBadgeDoor(int id)
        //{
        //    Dictionary<Badge, List<Door>> result = new Dictionary<Badge, List<Door>>();
        //    foreach (var item in _badgeDoor)
        //        if (item.Key.BadgeID == id)
        //            result.Add(item.Key, item.Value.ToList());
        //    return result;



        //badgeKey = _badgeDoor.Where(bd => bd.Key.BadgeID == id).Select(x => x.Value).ToList();
        //var badgeValues = badgeKey.Value.ToList();
        // result.Add(badgeKey, badgeValues);
        //




        //}
        //public Badge GetBadgeByDoorID(int id)
        //{
        //    var badge = _badge.FirstOrDefault(b => b.BadgeID == id);
        //    return badge;



        //}

        public void AddDoorToBadge(int id, Door door)
        {
            var badgeToUdpate = _badgeDoor.FirstOrDefault(x => x.Key == id);
           // List<Door> doorsList = new List<Door>();
            
            
            // doorToAdd = _doors.FirstOrDefault(b => b.DoorID == id).DoorName;

           

        }

        public void RemoveDoorFromBadge(int id, Door door)
        {

            throw new NotImplementedException();





        }
    }
}
