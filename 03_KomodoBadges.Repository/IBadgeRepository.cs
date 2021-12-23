using System.Collections.Generic;

namespace _03_KomodoBadges.Repository
{
    public interface IBadgeRepository
    {
        void CreateNewBadge(Badge badge);
        void DeleteBadge(int badgeID);
        List<Badge> GetAllBadges();
        Badge GetBadgeByID(int id);
    }
}