using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class BadgeRepository : IBadgeRepository
    {

        private readonly List<Badge> _badge;

        public BadgeRepository()
        {

            _badge = new List<Badge>();

        }

        public void CreateNewBadge(Badge badge)
        {

            _badge.Add(badge);
        }

        public List<Badge> GetAllBadges()
        {
            return _badge;
        }


        public Badge GetBadgeByID(int id)
        {
            var badge = _badge.FirstOrDefault(b => b.BadgeID == id);
            return badge;



        }
        public void DeleteBadge(int badgeID)
        {
            var badgeToDelete = GetBadgeByID(badgeID);
            if (badgeToDelete != null)
            {
                _badge.Remove(badgeToDelete);

            }
            else
            {
                Console.WriteLine("Badge does not exist.");
            }
        }



    }
}
